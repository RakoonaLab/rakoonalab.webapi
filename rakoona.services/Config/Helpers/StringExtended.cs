using rakoona.models.dtos.Request;
using rakoona.services.Entities.Models.Pacientes;
using rakoona.services.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace rakoona.services.Config.Helpers
{
    internal static class StringExtended
    {
        public static bool IsStringEmpty(this string request)
        {
            request = request.Replace(" ", String.Empty);
            return request == null || request == "" ? true : false;
        }

        public static int ToNumber(this string request)
        {
            int value = Int32.Parse(request);
            return value;
        }
    }
}
