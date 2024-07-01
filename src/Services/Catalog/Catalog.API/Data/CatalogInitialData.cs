namespace Catalog.API.Data
{
    public class CatalogInitialData : IInitialData
    {
        public async Task Populate(IDocumentStore store, CancellationToken cancellation)
        {
            using var session = store.LightweightSession();

            if(await session.Query<Product>().AnyAsync())
                return;

            session.Store<Product>(GetPreconfiguredProducts());
            await session.SaveChangesAsync();
        }

        private IEnumerable<Product> GetPreconfiguredProducts() => new List<Product>()
        {
            new Product()
            {
                Id = new Guid("801440EB-CC1D-4669-B349-49AB8A0956CE"),
                Name = "RTX 4090 Aorus Master",
                Description = "Geforce RTX 4090 Aorus Master 24gb Gddr6x 384-bit",
                ImageFile = "https://images.kabum.com.br/produtos/fotos/sync_mirakl/589578/Geforce-RTX-4090-Aorus-Master-24gb-Gddr6x-384-bit-Gv-n4090aorus-M-24gd_1717704213_gg.jpg",
                Category = new List<string> { "GPU" },
                Price = 2089990M
            },
            new Product()
            {
                Id = new Guid("6329AA67-7D0E-4AD0-83C4-EE258E198488"),
                Name = "AMD Ryzen 7 7800X3D",
                Description = "Processador AMD Ryzen 7 7800X3D, 5.0GHz Max Turbo, Cache 104MB, AM5, 8 Núcleos, Vídeo Integrado",
                ImageFile = "https://images.kabum.com.br/produtos/fotos/426262/processador-amd-ryzen-7-7800x3d-5-0ghz-max-turbo-cache-104mb-am5-8-nucleos-video-integrado-100-100000910wof_1680784502_gg.jpg",
                Category = new List<string> { "CPU"},
                Price = 264899M
            },
            new Product()
            {
                Id = new Guid("DE78F2D6-C9F8-4203-A069-7222A509C046"),
                Name = "AMD Ryzen 9 7950X",
                Description = "Processador AMD Ryzen 9 7950X, 5.7GHz Max Turbo, Cache 80MB, AM5, 16 Núcleos, Vídeo Integrado",
                ImageFile = "https://images.kabum.com.br/produtos/fotos/378411/processador-amd-ryzen-9-7950x-5-7ghz-max-turbo-cache-80mb-am5-16-nucleos-video-integrado-100-100000514wof_1662132759_gg.jpg",
                Category = new List<string> { "CPU" },
                Price = 354899M
            },
            new Product()
            {
                Id = new Guid("8E76C27B-E47E-432C-A609-0AC449A2F573"),
                Name = "RTX 4080 Super MSI",
                Description = "Placa de Vídeo RTX 4080 Super MSI 16G Ventus 3X OC NVIDIA GeForce, 16GB GDDR6X, DLSS, Ray Tracing",
                ImageFile = "https://images.kabum.com.br/produtos/fotos/520528/placa-de-video-rtx-4080-super-msi-16g-ventus-3x-oc-nvidia-geforce-16gb-gddr6x-dlss-ray-tracing_1706527331_gg.jpg",
                Category = new List<string> { "GPU" },
                Price = 799999M
            },
            new Product()
            {
                Id = new Guid("5E2A2342-69F5-4E24-A48A-0FD50AB1E74A"),
                Name = "Gigabyte Z790 Aorus Xtreme X",
                Description = "Placa Mãe Gigabyte Z790 Aorus Xtreme X, Chipset Z790, Intel Lga 1700, Wi-fi, E-atx, Ddr5",
                ImageFile = "https://images.kabum.com.br/produtos/fotos/sync_mirakl/573248/Placa-M-e-Gigabyte-Z790-Aorus-Xtreme-X-Chipset-Z790-Intel-Lga-1700-Wi-fi-E-atx-Ddr5_1719321299_gg.jpg",
                Category = new List<string> { "MOBO" },
                Price = 1245976M
            }
        };
    }
}
