namespace MinimalApiDemo.Api.Services.PornStars;

public class PornStarService : IPornStarService
{
    public PornStar GetPornStarById(int id)
    {
        var pornStars = this.GetPornStars();

        var pornStar = pornStars.FirstOrDefault(x => x.Id == id);

        return pornStar;
    }

    public IEnumerable<PornStar> GetPornStars()
    {
        var pornStars = new PornStar[]
        {
           new PornStar
           {
               Id = 1,
               FullName = "Adriana Chechik",
               Birthdate = DateTime.Parse("04/11/1991"),
               Address = "Downingtown, Пенсилвания, САЩ",
               Height = 157,
               Category = Category.Hardcore,
           },
           new PornStar
           {
               Id = 2,
               FullName = "Gina Valentina",
               Birthdate = DateTime.Parse("18/02/1997"),
               Address = "Рио де Жанейро, Рио де Жанейро, Бразилия",
               Height = 157,
               Category = Category.Hardcore,
           },
           new PornStar
           {
               Id = 3,
               FullName = "Lana Rhoades",
               Birthdate = DateTime.Parse("06/09/1996"),
               Address = "Макхенри, Илинойс, САЩ",
               Height = 160,
               Category = Category.Hardcore,
           },
           new PornStar
           {
               Id = 4,
               FullName = "Emily Willis",
               Birthdate = DateTime.Parse("29/12/1998"),
               Address = "Юта, САЩ",
               Height = 165,
               Category = Category.Hardcore,
           },
           new PornStar
           {
               Id = 5,
               FullName = "Riley Reid",
               Birthdate = DateTime.Parse("09/07/1991"),
               Address = "Маями, Флорида, САЩ",
               Height = 163,
               Category = Category.Hardcore,
           },
        };

        var pornStarsWithAges = pornStars
            .Select(x => new PornStar
            {
                Id = x.Id,
                FullName = x.FullName,
                Birthdate = x.Birthdate,
                Address = x.Address,
                Category = x.Category,
                Height = x.Height,
                Age = (byte)((DateTime.Now - x.Birthdate).Days / 365),
            })
            .ToArray();

        return pornStarsWithAges;
    }
}
