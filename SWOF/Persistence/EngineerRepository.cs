using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SWOF.Core.Models;
using SWOF.Core.Resources;
using SWOF.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SWOF.Persistence
{
    public class EngineerRepository : IEngineerRepository
    {
        private readonly BauDbContext _context;
        private DbSet<Engineer> _entities;
        private IMapper _mapper;

        public EngineerRepository(BauDbContext context, IMapper mapper)
        {
            _context = context;
            _entities = _context.Set<Engineer>();
            _mapper = mapper;
        }

        public IEnumerable<EngineerModel> ReadAll()
        {
            return _mapper.Map<IEnumerable<EngineerModel>>(_entities.ToList());
        }

        public void Add(EngineerModel engineer)
        {
            var entity = _mapper.Map<Engineer>(engineer);
            _entities.Add(entity);
            _context.SaveChanges();
        }

        public void Remove(int id)
        {
            var entity = _entities.Find(id);
            _entities.Remove(entity);
            _context.SaveChanges();
        }

        public EngineerModel Find(int id)
        {
            var entity = _entities.Find(id);
            return _mapper.Map<EngineerModel>(entity);
        }
    }
}
