#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymApp.Data;
using GymApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
/*using System.Data;*/

namespace GymApp.Controllers
{
    public class GymsController : Controller
    {
        private readonly GymAppContext _context;

        public GymsController(GymAppContext context)
        {
            _context = context;
        }

        // GET: Gyms
        public async Task<IActionResult> Index(string targetMuscle, string searchString)
        {
            // Use LINQ to get list of muscles.
            IQueryable<string> muscleQuery = from m in _context.Gym
                                             orderby m.FocusOn
                                             select m.FocusOn;

            var gyms = from m in _context.Gym
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                gyms = gyms.Where(s => s.Excercise!.Contains(searchString));
            }

            if(!string.IsNullOrEmpty(targetMuscle))
            {
                gyms = gyms.Where(x => x.FocusOn == targetMuscle);
            }

            var targetMuscleVM = new TargetMuscleViewModel
            {
                Muscles = new SelectList(await muscleQuery.Distinct().ToListAsync()),
                Gyms = await gyms.ToListAsync()
            };

            return View(targetMuscleVM);
        }

        // GET: Gyms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gym = await _context.Gym
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gym == null)
            {
                return NotFound();
            }

            return View(gym);
        }

        // GET: Gyms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gyms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Excercise,FocusOn,Sets,Reps, Weight")] Gym gym)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gym);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gym);
        }

        // GET: Gyms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gym = await _context.Gym.FindAsync(id);
            if (gym == null)
            {
                return NotFound();
            }
            return View(gym);
        }

        // POST: Gyms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Excercise,FocusOn,Sets,Reps,Weight")] Gym gym)
        {
            if (id != gym.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gym);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GymExists(gym.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(gym);
        }

        // GET: Gyms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gym = await _context.Gym
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gym == null)
            {
                return NotFound();
            }

            return View(gym);
        }

        // POST: Gyms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gym = await _context.Gym.FindAsync(id);
            _context.Gym.Remove(gym);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GymExists(int id)
        {
            return _context.Gym.Any(e => e.Id == id);
        }
    }
}
