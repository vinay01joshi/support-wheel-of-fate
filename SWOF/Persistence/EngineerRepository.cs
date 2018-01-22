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
        private IMapper _mapper;

        public EngineerRepository(BauDbContext context, IMapper mapper)
        {
            _context = context;          
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
