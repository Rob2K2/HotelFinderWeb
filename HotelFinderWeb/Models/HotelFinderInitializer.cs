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
                    UserName = "AllisonBrown",
                    HotelPicture = getFileBytes("\\Images\\flower.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    RoomSummary = "Todas nuestras habitaciones contemporáneas incluyen minibares, TV de pantalla plana con programación de cable, servicio a la habitación las 24 horas, servicio de camareras con apertura de camas todas las noches, reloj despertador, desayuno incluido y balcones y terrazas estupendas. Con Wi-Fi sin costo, modernas estaciones de trabajo y tomas eléctricas de 110v-200v, el mantenerse productivo estando lejos de la oficina nunca fue tan fácil.",
                    Address="Av. San Martín #455",
                    Web="www.lostajiboshotel.com",
                    Phone="+591(3)3426994",
                    City="Santa Cruz",
                    UrlImage="http://www.macaws.net/hf/images/tajibos.jpg"
                },
                new Hotel {
                    Name = "LOS TAJIBOS HOTEL",
                    HotelSummary = "Descubre tu propio oasis privado en Santa Cruz, Bolivia, en Los Tajibos Hotel & Convention Center.\r\nEstamos ubicados en el exclusivo barrio residencial de Equipetrol a tan sólo 15 minutos del centro de la ciudad y a 30 minutos del Aeropuerto Internacional Viru Viru. El Hotel cuenta con todas las comodidades para una estadía placentera y una excelente y variada oferta gastronómica. A pasos del Hotel encontrarán tiendas comerciales, lugares de entretenimiento y joyerías.",
                    UserName = "AllisonBrown",
                    HotelPicture = getFileBytes("\\Images\\flower.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    RoomSummary = "Todas nuestras habitaciones contemporáneas incluyen minibares, TV de pantalla plana con programación de cable, servicio a la habitación las 24 horas, servicio de camareras con apertura de camas todas las noches, reloj despertador, desayuno incluido y balcones y terrazas estupendas. Con Wi-Fi sin costo, modernas estaciones de trabajo y tomas eléctricas de 110v-200v, el mantenerse productivo estando lejos de la oficina nunca fue tan fácil.",
                    Address="Av. San Martín #455",
                    Web="www.lostajiboshotel.com",
                    Phone="+591(3)3426994",
                    City="Santa Cruz",
                    UrlImage="http://www.macaws.net/hf/images/tajibos.jpg"
                },
                new Hotel {
                    Name = "LOS TAJIBOS HOTEL",
                    HotelSummary = "Descubre tu propio oasis privado en Santa Cruz, Bolivia, en Los Tajibos Hotel & Convention Center.\r\nEstamos ubicados en el exclusivo barrio residencial de Equipetrol a tan sólo 15 minutos del centro de la ciudad y a 30 minutos del Aeropuerto Internacional Viru Viru. El Hotel cuenta con todas las comodidades para una estadía placentera y una excelente y variada oferta gastronómica. A pasos del Hotel encontrarán tiendas comerciales, lugares de entretenimiento y joyerías.",
                    UserName = "AllisonBrown",
                    HotelPicture = getFileBytes("\\Images\\flower.jpg"),
                    ImageMimeType = "image/jpeg",
                    CreatedDate = DateTime.Today.AddDays(-5),
                    RoomSummary = "Todas nuestras habitaciones contemporáneas incluyen minibares, TV de pantalla plana con programación de cable, servicio a la habitación las 24 horas, servicio de camareras con apertura de camas todas las noches, reloj despertador, desayuno incluido y balcones y terrazas estupendas. Con Wi-Fi sin costo, modernas estaciones de trabajo y tomas eléctricas de 110v-200v, el mantenerse productivo estando lejos de la oficina nunca fue tan fácil.",
                    Address="Av. San Martín #455",
                    Web="www.lostajiboshotel.com",
                    Phone="+591(3)3426994",
                    City="Santa Cruz",
                    UrlImage="http://www.macaws.net/hf/images/tajibos.jpg"
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