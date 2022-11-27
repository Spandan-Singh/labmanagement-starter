using CapstoneData.Model;
using Microsoft.EntityFrameworkCore;

namespace CapstoneData.Provider
{
    public class LabProvider : ILabProvider
    {
        private readonly ICapstoneDBContext _context;
        public LabProvider(ICapstoneDBContext context)
        {
            _context = context;
        }
        public Lab CreateLab(Lab lab)
        {
            LabDbo labDboToCreate = new LabDbo
            {
                Name = lab.Name,
                Description = lab.Description,
                AutherId = lab.Auther.Id,
                CategoryId = lab.Category.Id,
                Id = lab.Id
            };
            _context.Labs.Add(labDboToCreate);
            _context.SaveChanges();
            return lab;
        }

        public bool DeleteLabById(int id)
        {
            LabDbo? labToRemove = _context.Labs.FirstOrDefault(lab => lab.Id == id);
            if (labToRemove is not null)
            {
                _context.Labs.Remove(labToRemove);
            }
            return _context.SaveChanges() is not 0;
        }

        public Lab? GetLabById(int id)
        {
            Lab labDetails = new();
            LabDbo lab = _context.Labs.FirstOrDefault(lab => lab.Id == id);

            if (lab is not null)
            {
                labDetails.Id= lab.Id;
                labDetails.Name= lab.Name;
                labDetails.Description= lab.Description;
                labDetails.Auther = _context.Authers.FirstOrDefault(auth => auth.Id == lab.AutherId);
                labDetails.Category = _context.Categories.FirstOrDefault(cat => cat.Id == lab.CategoryId);
            }
            return labDetails;
        }

        public IEnumerable<Lab> GetLabs()
        {
            foreach(LabDbo lab in _context.Labs)
            {
                yield return new Lab
                {
                    Id = lab.Id,
                    Name = lab.Name,
                    Description= lab.Description,  
                    Auther= _context.Authers.FirstOrDefault(auth => auth.Id == lab.AutherId),
                    Category = _context.Categories.FirstOrDefault(cat => cat.Id == lab.CategoryId)
                };
            }

        }

        public Lab UpdateLabById(int id, Lab lab)
        {
            LabDbo? labToModify = _context.Labs.FirstOrDefault(lab => lab.Id == id);
            if (labToModify is not null)
            {
                labToModify.Name = lab.Name;
                labToModify.Description = lab.Description;
                labToModify.AutherId = lab.Auther.Id;
                labToModify.CategoryId = lab.Category.Id;
                labToModify.Id = lab.Id;
                _context.SaveChanges();
            }
            return lab;
        }
    }
}
