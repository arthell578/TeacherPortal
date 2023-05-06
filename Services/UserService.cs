using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TeacherPortal.Entities;
using TeacherPortal.Models;

namespace TeacherPortal.Interfaces
{
    public class UserService : IUserService
    {
        private readonly TeacherPortalDbContext _dbContext;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly AuthenticationSetting _authenticationSetting;
        private readonly IMapper _mapper;

        public UserService(TeacherPortalDbContext dbContext, IPasswordHasher<User> passwordHasher, 
                AuthenticationSetting authenticationSetting, IMapper mapper)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _authenticationSetting = authenticationSetting;
            _mapper = mapper;
        }
        public void Register(RegisterUserDTO registerUserDTO)
        {
            var newUser = new User()
            {
                Email = registerUserDTO.Email,
                UserRole = registerUserDTO.UserRole,
                FirstName= registerUserDTO.FirstName,
                LastName= registerUserDTO.LastName,
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, registerUserDTO.Password);
            newUser.Password = hashedPassword;

            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public string GenerateJwtToken(LoginUserDTO loginUserDTO)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == loginUserDTO.Email);

            if(user == null) 
            {
                throw new Exception("Invalid username or password");
            }

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password,loginUserDTO.Password);

            if(result == PasswordVerificationResult.Failed) 
            {
                throw new Exception("Invalid username or password");
            }

            var claimList = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(ClaimTypes.Role, $"{user.UserRole}")
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSetting.JwtKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expires = DateTime.Now.AddDays(_authenticationSetting.JwtExpireDays);

            var jwtToken = new JwtSecurityToken(_authenticationSetting.JwtIssuer, _authenticationSetting.JwtIssuer,
                claimList, 
                expires: expires,
                signingCredentials: credentials);

            var tokenHandler = new JwtSecurityTokenHandler();

            return tokenHandler.WriteToken(jwtToken);
        }

        public async Task<bool> ChangePassword(int userId, ChangePasswordDTO changePasswordDTO)
        {
            var user = await _dbContext.Users.FindAsync(userId);

            if (user == null)
            {
                return false;
            }

            if (_passwordHasher.VerifyHashedPassword(user, user.Password, changePasswordDTO.OldPassword) == PasswordVerificationResult.Failed)
            {
                return false;
            }

            user.Password = _passwordHasher.HashPassword(user, changePasswordDTO.NewPassword);

            _dbContext.Entry(user).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public UserDTO GetUserByID(int id)
        {
            var user = _dbContext.Users.Find(id);

            if(user == null) 
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user);
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            var users = _dbContext.Users.ToList();
            return _mapper.Map<IEnumerable<UserDTO>>(users);
        }
    }
}
