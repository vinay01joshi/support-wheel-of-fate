using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWOF.Core.Models;
using SWOF.Core.Resources;
using SWOF.Data;
using System.Collections.Generic;
using System.Linq;

namespace SWOF.Persistence
{
    public class EngineerRepository : IEngineerRepository
    {
        private readonly BauDbContext _context;
        // private DbSet<Engineer> _entities;
        //private List<Engineer> _entities;
        private IMapper _mapper;

        public EngineerRepository(BauDbContext context, IMapper mapper)
        {
            _context = context;
            //_entities = new List<Engineer>()
            //{
            //        new Engineer {Id =1,  Name = "Vinay" },
            //        new Engineer {Id =2, Name = "Jitender" },
            //        new Engineer {Id =3, Name = "Shivam" },
            //        new Engineer {Id =4, Name = "Parvez" },
            //        new Engineer {Id =5, Name = "Pankaj" },
            //        new Engineer {Id =6, Name = "Subodh" },
            //        new Engineer {Id =7, Name = "Peeyush" },
            //        new Engineer {Id =8, Name = "Harsh" },
            //        new Engineer {Id =9, Name = "Tanvi" },
            //        new Engineer {Id =10, Name = "Harry" }
            //};
            _mapper = mapper;
        }

        public IEnumerable<EngineerModel> ReadAll()
        {
            return _mapper.Map<IEnumerable<EngineerModel>>(_context.Engineer.ToList());
        }

        public void Add(EngineerModel engineer)
        {
            var entity = _mapper.Map<Engineer>(engineer);
            _context.Engineer.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _context.Engineer.Find(id);
            _context.Engineer.Remove(entity);
            _context.SaveChanges();
        }

        public EngineerModel Find(int id)
        {
            var entity = _context.Engineer.Find(id);
            return _mapper.Map<EngineerModel>(entity);
        }
    }
}
