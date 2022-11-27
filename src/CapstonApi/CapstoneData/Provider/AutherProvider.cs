using CapstoneData.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapstoneData.Provider
{
    public class AutherProvider: IAutherProvider
    {
        private readonly ICapstoneDBContext _context;
        public AutherProvider(ICapstoneDBContext context)
        {
            _context = context;
        }
        public IEnumerable<AutherDbo> GetAuthers()
        {
            return _context.Authers;
        }


        public AutherDbo? GetAutherById(int id)
        {
            return _context.Authers.FirstOrDefault(auth => auth.Id == id);
        }

        public AutherDbo CreateAuther(AutherDbo auther)
        {
            _context.Authers.Add(auther);
            _context.SaveChanges();
            return auther;
        }
        public AutherDbo UpdateAutherById(int id, AutherDbo auther)
        {
            AutherDbo? autherToModify = _context.Authers.FirstOrDefault(auth => auth.Id == id);
            if(autherToModify is not null)
            {
                autherToModify.FirstName = auther.FirstName;
                autherToModify.LastName = auther.LastName;
                _context.SaveChanges();
            }
            return autherToModify;
        }
        public bool DeleteAutherById(int id)
        {
            AutherDbo? autherToRemove = _context.Authers.FirstOrDefault(auth => auth.Id == id);
            if (autherToRemove is not null)
            {
                _context.Authers.Remove(autherToRemove);
            }
            return _context.SaveChanges() is not 0;
        }
    }
}
