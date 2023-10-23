using Globe_Wander_Final.Data;
using Globe_Wander_Final.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Globe_Wander_Final.Models.Services
{
    public class UPDATEBOOKINGTRIPServices
    {
        private readonly GlobeWanderDbContext _context;

        public UPDATEBOOKINGTRIPServices(GlobeWanderDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int Id)
        {
            var UPDATEBOOKINGTEMP = await _context.UPDATEBOOKINGTRIPs.FindAsync(Id);

            _context.Entry<UPDATEBOOKINGTRIP>(UPDATEBOOKINGTEMP).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }

        public async Task<UPDATEBOOKINGTRIP> get(int Id)
        {
            var UPDATEBOOKINGTEMP = await _context.UPDATEBOOKINGTRIPs.FindAsync(Id);


            return UPDATEBOOKINGTEMP;

        }
        public async Task<UPDATEBOOKINGTRIP> Create(DurationBookingTripDTO updated )
        {
            UPDATEBOOKINGTRIP uPDATEBOOKINGTREP = new UPDATEBOOKINGTRIP()
            {
                IdForUpdate= updated.ID,
            StartDate = updated.StartDate,
            EndDate = updated.EndDate,

            };


            _context.UPDATEBOOKINGTRIPs.Add(uPDATEBOOKINGTREP);
            await _context.SaveChangesAsync();
            return uPDATEBOOKINGTREP;
        }

    }
}
