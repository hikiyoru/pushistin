using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using System.IO;
using System.Text;

namespace pushistin.Models {

    public static class StoreSeedData {

        public static void EnsurePopulated(IApplicationBuilder app) {
            StoreDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<StoreDbContext>();

            if (context.Database.GetPendingMigrations().Any()) {
                context.Database.Migrate();
            }
            if (!context.Products.Any()) {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Пауч Purina Pro Plan, ягненок",
                        Brand = "Purina Pro Plan",
                        Description = "Влажный корм для взрослых кошек с чувствительным пищеварением. Хорошо усвояемые ингредиенты. Снижает риск возникновения кожных реакций, вызываемых непереносимостью к пище.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "85 г",
                        Price = 2.71m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/1.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Purina Pro Plan, индейка",
                        Brand = "Purina Pro Plan",
                        Description = "Влажный корм для взрослых кошек с чувствительным пищеварением. Хорошо усвояемые ингредиенты. Снижает риск возникновения кожных реакций, вызываемых непереносимостью к пище.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "85 г",
                        Price = 2.71m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/2.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Purina Pro Plan, океаническая рыба",
                        Brand = "Purina Pro Plan",
                        Description = "Влажный корм для взрослых кошек с чувствительным пищеварением. Хорошо усвояемые ингредиенты. Снижает риск возникновения кожных реакций, вызываемых непереносимостью к пище.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "85 г",
                        Price = 2.71m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/3.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Purina Pro Plan, лосось",
                        Brand = "Purina Pro Plan",
                        Description = "Влажный корм для взрослых кошек с чувствительным пищеварением. Хорошо усвояемые ингредиенты. Снижает риск возникновения кожных реакций, вызываемых непереносимостью к пище.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "85 г",
                        Price = 2.71m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/4.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Purina Pro Plan, курица",
                        Brand = "Purina Pro Plan",
                        Description = "Влажный корм для взрослых кошек с чувствительным пищеварением. Хорошо усвояемые ингредиенты. Снижает риск возникновения кожных реакций, вызываемых непереносимостью к пище.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "85 г",
                        Price = 2.71m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/5.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Royal Canin, кусочки в соусе",
                        Brand = "Royal Canin",
                        Description = "Правильное питание поможет заложить основы здоровья вашего котенка. Получение незаменимых питательных веществ обеспечит ему необходимую поддержку на критически важных стадиях развития и после завершения роста.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "85 г",
                        Price = 2.33m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/6.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Royal Canin, паштет",
                        Brand = "Royal Canin",
                        Description = "Правильное питание поможет заложить основы здоровья вашего котенка. Получение незаменимых питательных веществ обеспечит ему необходимую поддержку на критически важных стадиях развития и после завершения роста.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "85 г",
                        Price = 2.19m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/7.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Sheba, индейка",
                        Brand = "Sheba",
                        Description = "Используя богатый опыт в приготовлении изысканных блюд для кошек, специалисты создали эту особенную коллекцию. Позвольте вашей кошке насладиться восхитительным вкусом  SHEBA® NATURE'S COLLECTION™.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "75 г",
                        Price = 1.59m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/8.jpg"),
                    },
                    new Product
                    {
                        Name = "Пауч Sheba, форель и креветки",
                        Brand = "Sheba",
                        Description = "Используя богатый опыт в приготовлении изысканных блюд для кошек, специалисты создали эту особенную коллекцию. Позвольте вашей кошке насладиться восхитительным вкусом  SHEBA® NATURE'S COLLECTION™.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "75 г",
                        Price = 1.59m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/9.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Sheba, лосось",
                        Brand = "Sheba",
                        Description = "Используя богатый опыт в приготовлении изысканных блюд для кошек, специалисты создали эту особенную коллекцию. Позвольте вашей кошке насладиться восхитительным вкусом  SHEBA® NATURE'S COLLECTION™.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "75 г",
                        Price = 1.59m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/10.jpg"),
                    },
                    new Product
                    {
                        Name = "Пауч Sheba, курица",
                        Brand = "Sheba",
                        Description = "Используя богатый опыт в приготовлении изысканных блюд для кошек, специалисты создали эту особенную коллекцию. Позвольте вашей кошке насладиться восхитительным вкусом  SHEBA® NATURE'S COLLECTION™.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "75 г",
                        Price = 1.59m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/11.jpg"),
                    },
                    new Product
                    {
                        Name = "Пауч Sheba, курица и кролик",
                        Brand = "Sheba",
                        Description = "Используя богатый опыт в приготовлении изысканных блюд для кошек, специалисты создали эту особенную коллекцию. Позвольте вашей кошке насладиться восхитительным вкусом  SHEBA® NATURE'S COLLECTION™.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "75 г",
                        Price = 1.59m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/12.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Sheba, говядина и кролик",
                        Brand = "Sheba",
                        Description = "Используя богатый опыт в приготовлении изысканных блюд для кошек, специалисты создали эту особенную коллекцию. Позвольте вашей кошке насладиться восхитительным вкусом  SHEBA® NATURE'S COLLECTION™.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "75 г",
                        Price = 1.59m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/13.webp"),
                    },
                    new Product
                    {
                        Name = "Пауч Sheba, утка",
                        Brand = "Sheba",
                        Description = "Используя богатый опыт в приготовлении изысканных блюд для кошек, специалисты создали эту особенную коллекцию. Позвольте вашей кошке насладиться восхитительным вкусом  SHEBA® NATURE'S COLLECTION™.",
                        Category = "Влажные корма",
                        Pet = "Кошки",
                        Weight = "75 г",
                        Price = 1.59m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/14.jpg"),
                    },
                    new Product
                    {
                        Name = "Сухой корм Purina Pro Plan, индейка",
                        Brand = "Purina Pro Plan",
                        Description = "",
                        Category = "Сухие корма",
                        Pet = "Кошки",
                        Weight = "1.5 кг",
                        Price = 47.17m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/15.webp"),
                    },
                    new Product
                    {
                        Name = "Сухой корм Purina Pro Plan, курица",
                        Brand = "Purina Pro Plan",
                        Description = "",
                        Category = "Сухие корма",
                        Pet = "Кошки",
                        Weight = "1.5 кг",
                        Price = 47.17m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/16.webp"),
                    },
                    new Product
                    {
                        Name = "Лакомство For Friends, кабаносы для кошек из утки",
                        Brand = "For Friends",
                        Description = "100% натуральные ингредиенты, удобный размер и форма. 100% натуральные ингредиенты, удобный размер и форма. Лакомство для кошек «For Friends» Кабаносы из утки - это натуральное лакомство,  которое подойдет для любой породы кошек старше 3-х месяцев.",
                        Category = "Лакомства",
                        Pet = "Кошки",
                        Weight = "50 г",
                        Price = 5.83m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/17.webp"),
                    },
                    new Product
                    {
                        Name = "Таблетки от блох и клещей Фронтлайн НЕКСГАРД M, 28,3 мг, 4,1-10 кг, 1 таблетка",
                        Brand = "MERIAL",
                        Description = "Лекарственная форма: таблетки для орального применения (жевательные). Фронтлайн НексгарД выпускают в четырех дозировках: таблетки массой 0,5 г; 1,25 г; 3,0 г; и 6,0 г, содержащие в качестве действующего вещества 2,27% афоксоланера (соответственно 11,3 мг; 28,3 мг; 68 мг и 136 мг в таблетке), а также вспомогательные вещества: кукурузный крахмал – 25%, муку из соевого белка – 20%, добавку с ароматом и вкусом тушеной говядины – 20%, повидон К30 – 2,7%, макрогол 400 – 7,1%, макрогол 4000 – 6,3%, макрогол 15 гидроксистеарат – 3,1%, глицерол – 10%, триглицерид средней степени – 3,1%, сорбат калия – 0,3%.",
                        Category = "Лекарство",
                        Pet = "Собаки",
                        Weight = "",
                        Price = 28.99m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/18.webp"),
                    },
                    new Product
                    {
                        Name = "Силикагелевый наполнитель Кошкина Полянка, с ароматом яблока",
                        Brand = "Кошкина Полянка",
                        Description = "Кошкина Полянка Силикагелевый (Яблоко) - это силикагелевый наполнитель для кошачьих туалетов с ароматом яблока. Запах не раздражает чувствительное обоняние кошки.",
                        Category = "Наполнитель",
                        Pet = "Кошки",
                        Weight = "3 кг (7,6 л)",
                        Price = 56.99m,
                        IsStock = true,
                        ByteImage = System.IO.File.ReadAllBytes("wwwroot/img/SeedProducts/19.webp"),
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
