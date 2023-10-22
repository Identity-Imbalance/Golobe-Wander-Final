using Globe_Wander_Final.Data;
using Globe_Wander_Final.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Globe_Wander_Final.Models.Services
{
    public class UPDATEBOOKINGTEMPServices
    {
        private readonly GlobeWanderDbContext _context;

        public UPDATEBOOKINGTEMPServices(GlobeWanderDbContext context)
        {
            _context = context;
        }
        public async Task Delete(int Id)
        {
            var UPDATEBOOKINGTEMP = await _context.UPDATEBOOKINGTEMPs.FindAsync(Id);

            _context.Entry<UPDATEBOOKINGTEMP>(UPDATEBOOKINGTEMP).State = EntityState.Deleted;

            await _context.SaveChangesAsync();

        }

        public async Task<UPDATEBOOKINGTEMP> get(int Id)
        {
            var UPDATEBOOKINGTEMP = await _context.UPDATEBOOKINGTEMPs.FindAsync(Id);


            return UPDATEBOOKINGTEMP;

        }
        public async Task<UPDATEBOOKINGTEMP> Create(DurationBookingRoomDTO updated )
        {
            UPDATEBOOKINGTEMP uPDATEBOOKINGTEMP = new UPDATEBOOKINGTEMP()
            {
                IdForUpdate= updated.ID,
            CheckIn = updated.CheckIn,
            CheckOut = updated.CheckOut,

            };


            _context.UPDATEBOOKINGTEMPs.Add(uPDATEBOOKINGTEMP);
            await _context.SaveChangesAsync();
            return uPDATEBOOKINGTEMP;
        }

    }
}
