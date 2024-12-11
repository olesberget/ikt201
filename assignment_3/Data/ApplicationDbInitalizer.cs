using assignment_3.Models;
namespace assignment_3.Data {
    public static class ApplicationDbInitializer {
        public static void Initialize(ApplicationDbContext db) {
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            var guestbooks = new[]
            {
                new Guestbook("Roger Hansen", "Sjef", "Jeg trenger badekar for et flott opphold"),
                new Guestbook("Knut Johnsen", "Selger", "Jeg trenger inkeltseng, fordi dobbeltseng er for stort"),
            };
            db.Guestbooks.AddRange(guestbooks);
            db.SaveChanges();
        }
    }
}