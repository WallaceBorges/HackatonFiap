using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Messages.Settings
{
    public class MailSettings
    {
       
            public static string? Account => "HackatonFiap2024@gmail.com";
            public static string? Password => "!@#Senha";
            public static string? Smtp => "smtp.gmail.com";
            public static int? Port => 587;
       
    }
}
