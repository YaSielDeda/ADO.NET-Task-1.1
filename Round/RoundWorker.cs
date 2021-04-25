using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Round
{
    public class RoundWorker
    {
        public Round GetRound(string path)
        {
            var round = GetRoundFromFile(path);
            if (RadiusCheck(round))
                return round;
            else
                throw new LessThanZero("The radius can only be positive");
        }
        private Round GetRoundFromFile(string path)
        {
            Round round = new Round();
            JsonSerializer json = new JsonSerializer();
            using (StreamReader sw = new StreamReader(path))
            {
                string output = sw.ReadToEnd();
                using (JsonReader jr = new JsonTextReader(sw))
                {
                    try
                    {
                        round = JsonConvert.DeserializeObject<Round>(output);
                    }
                    catch(FileNotFoundException)
                    {
                        throw new FileNotFoundException("The JSON file is missing!");
                    }
                    catch (JsonReaderException)
                    {
                        throw new JsonReaderException("The file contains prohibited symbols!");
                    }
                }
            }
            return round;
        }
        private bool RadiusCheck(Round round)
        {
            if (round.Radius < 0)
                return false;
            else
                return true;
        }
        public void ToFile(Round round)
        {
            JsonSerializer json = new JsonSerializer();
            if (RadiusCheck(round))
            {
                using (StreamWriter fs = new StreamWriter("output round.json"))
                {
                    using (JsonWriter jw = new JsonTextWriter(fs))
                    {
                        json.Serialize(jw, round);
                    }
                }
            }
            else
                throw new LessThanZero("The radius can only be positive");
        }
    }
}
