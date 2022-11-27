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
        public Lab CreateLab(LabDbo lab)
        {
            Lab labDboToCreate = new Lab
            {
                Name = lab.Name,
                Description = lab.Description,
                Auther = _context.Authers.FirstOrDefault(auth => auth.Id == lab.AutherId),
                Category = _context.Categories.FirstOrDefault(cat => cat.Id == lab.CategoryId),
                Id = lab.Id
            };
            _context.Labs.Add(lab);
            _context.SaveChanges();
            return labDboToCreate;
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
            IList<AutherDbo> authers = _context.Authers.ToList();
            IList<CategoryDbo> categories = _context.Categories.ToList();

            foreach (LabDbo lab in _context.Labs)
            {
                yield return new Lab
                {
                    Id = lab.Id,
                    Name = lab.Name,
                    Description= lab.Description,  
                    Auther= authers.FirstOrDefault(auth => auth.Id == lab.AutherId),
                    Category = categories.FirstOrDefault(cat => cat.Id == lab.CategoryId)
                };
            }

        }

        public Lab UpdateLabById(int id, LabDbo lab)
        {
            LabDbo? labToModify = _context.Labs.FirstOrDefault(lab => lab.Id == id);
            if (labToModify is not null)
            {
                labToModify.Name = lab.Name;
                labToModify.Description = lab.Description;
                labToModify.AutherId = lab.AutherId;
                labToModify.CategoryId = lab.CategoryId;
                _context.SaveChanges();
            }
            return new Lab
            {

                Name = lab.Name,
                Description = lab.Description,
                Auther = _context.Authers.FirstOrDefault(auth => auth.Id == labToModify.AutherId),
                Category = _context.Categories.FirstOrDefault(cat => cat.Id == labToModify.CategoryId),
                Id = lab.Id
            };
        }
    }
}
