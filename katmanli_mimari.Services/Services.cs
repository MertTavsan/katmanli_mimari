using katmanli_mimari.Data;
using Microsoft.EntityFrameworkCore;

namespace katmanli_mimari.Services;


public class Service
{
    private readonly AppDbContext _context;

    public Service(AppDbContext context)
    {
        _context=context;
    }
       public string GetUserName(string ad,string soyad)
        {
            return ad+ " "+soyad;
        }

        public  async Task<List<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public  async Task<List<User>> GetUserByIDAsync(int id)
        {
            return await _context.Users.Where(u => u.Id == id).ToListAsync();
        }

 public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
}
