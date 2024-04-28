using Project_api.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project_api.Context;

namespace Project_api.Repository
{
    public interface IEnemyRepository
    {
        Task<List<Enemys>> GetAllEnemies();
        Task<Enemys?> GetEnemyById(int enemyId);
        Task<Enemys> CreateEnemy(Enemys enemy);
        Task<Enemys> UpdateEnemy(Enemys enemy);
        Task<bool> DeleteEnemy(int enemyId);
    }

    public class EnemyRepository : IEnemyRepository
    {
        private readonly DbProject _context;

        public EnemyRepository(DbProject context)
        {
            _context = context;
        }

        public async Task<List<Enemys>> GetAllEnemies()
        {
            return await _context.enemys.ToListAsync();
        }

        public async Task<Enemys?> GetEnemyById(int enemyId)
        {
            return await _context.enemys.FindAsync(enemyId);
        }

        public async Task<Enemys> CreateEnemy(Enemys enemy)
        {
            _context.enemys.Add(enemy);
            await _context.SaveChangesAsync();
            return enemy;
        }

        public async Task<Enemys> UpdateEnemy(Enemys enemy)
        {
            _context.Entry(enemy).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return enemy;
        }

        public async Task<bool> DeleteEnemy(int enemyId)
        {
            var enemy = await _context.enemys.FindAsync(enemyId);
            if (enemy == null)
            {
                return false;
            }

            _context.enemys.Remove(enemy);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
