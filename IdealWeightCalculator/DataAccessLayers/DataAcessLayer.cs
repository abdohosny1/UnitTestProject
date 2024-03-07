using IdealWeightCalculator.Data;
using IdealWeightCalculator.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdealWeightCalculator.DataAccessLayers
{
    public class DataAcessLayer
    {
        private readonly ApplicationDbContext _context;
        public DataAcessLayer(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User GetUserByName(string name)
        {
      return _context.Users.SingleOrDefault(e=>e.Name== name);
        }

        public User GetUserById(int id)
        {
            return _context.Users.Find(id);
        }
    }
}
