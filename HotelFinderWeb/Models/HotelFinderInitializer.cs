using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace PhotoSharingApplication.Models
{
    public class HotelFinderInitializer : DropCreateDatabaseAlways<HotelFinderContext>
    {
        //This method puts sample data into the database
        protected override void Seed(HotelFinderContext context)
        {
            base.Seed(context);

            //Create some photos
            var photos = new List<Hotel>
            {
                new Hotel {
                    Name = "LOS TAJIBOS HOTEL",
                    HotelSummary = "Descubre tu propio oasis privado en Santa Cruz, Bolivia, en Los Tajibos Hotel & Convention Center.\r\nEstamos ubicados en el exclusivo barrio residencial de Equipetrol a tan sólo 15 minutos del centro de la ciudad y a 30 minutos del Aeropuerto Internacional Viru Viru. El Hotel cuenta con todas las comodidades para una estadía placentera y una excelente y variada oferta gastronómica. A pasos del Hotel encontrarán tiendas comerciales, lugares de entretenimiento y joyerías.",
                    UserName = "RobertoMerino",
                    HotelPicture = getFileBytes("\\Images\\tajibos.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    RoomSummary = "Todas nuestras habitaciones contemporáneas incluyen minibares, TV de pantalla plana con programación de cable, servicio a la habitación las 24 horas, servicio de camareras con apertura de camas todas las noches, reloj despertador, desayuno incluido y balcones y terrazas estupendas. Con Wi-Fi sin costo, modernas estaciones de trabajo y tomas eléctricas de 110v-200v, el mantenerse productivo estando lejos de la oficina nunca fue tan fácil.",
                    Address="Av. San Martín #455",
                    Web="www.lostajiboshotel.com",
                    Phone="+591(3)3426994",
                    City="Santa Cruz",
                    UrlImage="www.macaws.net/hf/images/tajibos.jpg"
                },
                new Hotel {
                    Name = "HOTEL PRESIDENTE",
                    HotelSummary = "Cinco estrellas de categoría, ubicado en el centro de la ciudad de La Paz, cerca al área histórica, cultural, política y comercial. Situado cerca a los museos de historia, arte, etnografía y folklore; a pocos pasos de la \"Basílica Mayorr de San Francisco\", una de las obras arquitectónicas más representativas de la ciudad. Cerca al \"Mercado de las Brujas\", a pocos pasos de las principales tiendas de artesanía.",
                    UserName = "RobertoMerino",
                    HotelPicture = getFileBytes("\\Images\\presidente.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    RoomSummary = "Las habitaciones, cálidamente decoradas y amobladas,\r\nestán equipadas con todo lo necesario para que usted\r\nse sienta en casa. Todas las habitaciones cuentan con\r\ntelevisores LED, servicio a la habitación las 24 horas,\r\nmini-bar totalmente equipado, entre otros…",
                    Address="C. Potosí #920",
                    Web="www.lostajiboshotel.com",
                    Phone="+591(2)2406666",
                    City="La Paz",
                    UrlImage="www.macaws.net/hf/images/tajibos.jpg"
                },
                new Hotel {
                    Name = "HOTEL CESAR'S PLAZA",
                    HotelSummary = "\r\n\r\nCESAR’S PLAZA HOTEL S.R.L., Fue fundada por el empresario Cochabambino Sr. Luis Perez Argote el 14 de Septiembre de 1988, fue premiada por el Honorable Consejo Municipal de Cochabamba  con el premio municipal a la industria Hotelera, asi como también fue reconocida internacionalmente con los siguientes premios:\r\n\r\n1990 XV TROFEO INTERNACIONAL DE TURISMO Y HOSTELERIA otorgado en Madrid España y el año 1992 obtuvo el XX TROFEO DE ORO A LA CALIDAD otorgado también en Madrid - España. RECONOCIDO COMO UNO DE LOS 15 MEJORES HOTELES DE BOLIVIA SEGÚN LA REVISTA ESPECIALIZADA CASH…\r\n",
                    UserName = "RobertoMerino",
                    HotelPicture = getFileBytes("\\Images\\cesarsplaza.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    RoomSummary = "Cómodas y confortables Suites y habitaciones ideales para un descanso placentero y reparador, contamos con los siguientes servicios:\r\n\r\nFRIGOBAR, BAÑO PRIVADO CON TINA, DDI Y DDN, TV CABLE CON MÁS DE 100 CANALES NACIONALES E INTERNACIONALES, AIRE ACONDICIONADO FRIO/CALOR, CAJAS DE SEGURIDAD, INTERNET WI –FI. UNICO HOTEL EN SU CATEGORIA CON LA TECNOLOGIA DE CHAPAS MAGNETICAS QUE OFRECEN EXTREMA SEGURIDAD Y MODERNIDAD.",
                    Address="C. 25 de mayo #210",
                    Web="www.cesarsplaza.com.bo",
                    Phone="+591(4)4673276",
                    City="Cochabamba",
                    UrlImage="www.cesarsplaza.com.bo"
                },
                 new Hotel {
                    Name = "HOTEL REGINA",
                    HotelSummary = "Hotel regina se encuentra en el pleno centro de la ciudad siendo el mejor punto de partida para iniciar sus actividades turísticas, vacacionales o laborales.",
                    UserName = "AllisonBrown",
                    HotelPicture = getFileBytes("\\Images\\regina.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    RoomSummary = "Nuestras habitaciones cuentan con WIFI gratuito. Además ponemos a su disposición: Cambio de moneda, Caja de Seguridad, Servicio a la Habitación, Servicio de Lavandería, Servicio de Fax, Telefonía Nacional e Internacional, Canchas de Soccer, Servicio de Restaurant y Snack.",
                    Address="Av. Ecologica #4350",
                    Web="www.hotelregina.bo",
                    Phone="+591(4)6549247",
                    City="Cochabamba",
                    UrlImage="www.cesarsplaza.com.bo"
                }
            };
            photos.ForEach(s => context.Photos.Add(s));
            context.SaveChanges();

            //Create some comments
            var comments = new List<Comment>
            {
                new Comment {
                    HotelID = 1,
                    UserName = "JamieStark",
                    Subject = "Sample Comment 1",
                    Body = "This is the first sample comment in the Adventure Works photo application"
                },
                new Comment {
                    HotelID = 1,
                    UserName = "JimCorbin",
                    Subject = "Sample Comment 2",
                    Body = "This is the second sample comment in the Adventure Works photo application"
                }
            };
            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();
        }

        //This gets a byte array for a file at the path specified
        //The path is relative to the route of the web site
        //It is used to seed images
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }

    }
}