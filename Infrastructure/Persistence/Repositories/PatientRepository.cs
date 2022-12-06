using HenryScheinOneTest.Application.DTO;
using HenryScheinOneTest.Application.Interface;
using HenryScheinOneTest.Domain.Entities;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace HenryScheinOneTest.Infrastructure.Persistence.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        public async Task<string> GetAsync(IFormFile data)
        {
            string result = "";
            //var str = System.Text.Encoding.Default.GetString(data);
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(data.OpenReadStream());
            List<Patient> listOfPersons = new List<Patient>();
            var header = "";
            int count = 0;
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(',');
                if(count == 0)
                {
                    header = line;
                    count++;
                    continue;
                }
                if(line != "")
                    listOfPersons.Add(new Patient() {
                        Name = words[0].Trim(new Char[] { ' ', '*', '.', '"','/' }),
                        LastName = words[1].Trim(new Char[] { ' ', '*', '.', '"', '/' }),
                        SSN = words[2].Trim(new Char[] { ' ', '*', '.', '"', '/' }),
                        Age = words[3].Trim(new Char[] { ' ', '*', '.', '"', '/' }),
                        PhoneNumber = words[4].Trim(new Char[] { ' ', '*', '.', '"', '/' }),
                        Status = words[5].Trim(new Char[] { ' ', '*', '.', '"', '/' }),
                        Status2 = words[6].Trim(new Char[] { ' ', '*', '.', '"', '/' })
                    });
            }
            result = header + "\n";
            foreach (var item in listOfPersons)
            {
                result += "[" + item.Name + ", " + item.LastName + "]" + " "
                        + "[" + item.SSN + "]" + " " + "[" + item.Age + "]" + " "
                        + "[" + item.PhoneNumber + "]" + " " + "[" + item.Status + ", " + item.Status2 + "]" + "\n";
            }
            await Task.Delay(1);
            //await File.WriteAllTextAsync("WriteText.txt", text);
            file.Close();
            return result;
        }        
    }
}
