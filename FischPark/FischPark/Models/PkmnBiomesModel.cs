using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FischPark.Models
{
    public class PkmnBiomesModel
    {
        public int Count { get; set; }
        public string Pokemon { get; set; }
        public string Weather { get; set; }

        public PkmnBiomesModel(string pokemon, int count)
        {
            this.Pokemon = pokemon;
            this.Count = count;
        }

        public PkmnBiomesModel() { }
    }

    public class PkmnBiomesWeatherModel
    {
        public int Count { get; set; }
        public string Pokemon { get; set; }

        public PkmnBiomesWeatherModel(string pokemon, int count)
        {
            this.Pokemon = pokemon;
            this.Count = count;
        }

        public PkmnBiomesWeatherModel() { }
    }

    public class PkmnBiomesViewModel
    {
        public List<PkmnBiomesModel> fullList;
        public List<PkmnBiomesWeatherModel> clearList;
        public List<PkmnBiomesWeatherModel> partlyCloudyList;
        public List<PkmnBiomesWeatherModel> cloudyList;
        public List<PkmnBiomesWeatherModel> windyList;
        public List<PkmnBiomesWeatherModel> rainyList;
        public List<PkmnBiomesWeatherModel> snowyList;

        public PkmnBiomesViewModel(List<PkmnBiomesModel> dataModel)
        {
            fullList = new List<PkmnBiomesModel>();
            foreach (var item in dataModel)
            {
                if (!fullList.Any(p => p.Pokemon == item.Pokemon))
                {
                    fullList.Add(new PkmnBiomesModel(item.Pokemon, item.Count));
                }
                else
                {
                    int index = fullList.FindIndex(p => p.Pokemon == item.Pokemon);
                    fullList[index].Count += item.Count;
                }
            }
            fullList = fullList.OrderByDescending(i => i.Count).ToList();

            clearList = new List<PkmnBiomesWeatherModel>();
            foreach (var item in dataModel)
            {
                if (item.Weather == "Sunny" || item.Weather == "Clear")
                {
                    if (!clearList.Any(p => p.Pokemon == item.Pokemon))
                    {
                        clearList.Add(new PkmnBiomesWeatherModel(item.Pokemon, item.Count));
                    }
                    else
                    {
                        int index = clearList.FindIndex(p => p.Pokemon == item.Pokemon);
                        clearList[index].Count += item.Count;
                    }
                }
            }
            clearList = clearList.OrderByDescending(i => i.Count).ToList();

            partlyCloudyList = new List<PkmnBiomesWeatherModel>();
            foreach (var item in dataModel)
            {
                if (item.Weather == "Partly Cloudy")
                {
                    if (!partlyCloudyList.Any(p => p.Pokemon == item.Pokemon))
                    {
                        partlyCloudyList.Add(new PkmnBiomesWeatherModel(item.Pokemon, item.Count));
                    }
                    else
                    {
                        int index = partlyCloudyList.FindIndex(p => p.Pokemon == item.Pokemon);
                        partlyCloudyList[index].Count += item.Count;
                    }
                }
            }
            partlyCloudyList = partlyCloudyList.OrderByDescending(i => i.Count).ToList();

            cloudyList = new List<PkmnBiomesWeatherModel>();
            foreach (var item in dataModel)
            {
                if (item.Weather == "Cloudy")
                {
                    if (!cloudyList.Any(p => p.Pokemon == item.Pokemon))
                    {
                        cloudyList.Add(new PkmnBiomesWeatherModel(item.Pokemon, item.Count));
                    }
                    else
                    {
                        int index = cloudyList.FindIndex(p => p.Pokemon == item.Pokemon);
                        cloudyList[index].Count += item.Count;
                    }
                }
            }
            cloudyList = cloudyList.OrderByDescending(i => i.Count).ToList();

            windyList = new List<PkmnBiomesWeatherModel>();
            foreach (var item in dataModel)
            {
                if (item.Weather == "Windy")
                {
                    if (!windyList.Any(p => p.Pokemon == item.Pokemon))
                    {
                        windyList.Add(new PkmnBiomesWeatherModel(item.Pokemon, item.Count));
                    }
                    else
                    {
                        int index = windyList.FindIndex(p => p.Pokemon == item.Pokemon);
                        windyList[index].Count += item.Count;
                    }
                }
            }
            windyList = windyList.OrderByDescending(i => i.Count).ToList();

            rainyList = new List<PkmnBiomesWeatherModel>();
            foreach (var item in dataModel)
            {
                if (item.Weather == "Rainy")
                {
                    if (!rainyList.Any(p => p.Pokemon == item.Pokemon))
                    {
                        rainyList.Add(new PkmnBiomesWeatherModel(item.Pokemon, item.Count));
                    }
                    else
                    {
                        int index = rainyList.FindIndex(p => p.Pokemon == item.Pokemon);
                        rainyList[index].Count += item.Count;
                    }
                }
            }
            rainyList = rainyList.OrderByDescending(i => i.Count).ToList();

            snowyList = new List<PkmnBiomesWeatherModel>();
            foreach (var item in dataModel)
            {
                if (item.Weather == "Snowy")
                {
                    if (!snowyList.Any(p => p.Pokemon == item.Pokemon))
                    {
                        snowyList.Add(new PkmnBiomesWeatherModel(item.Pokemon, item.Count));
                    }
                    else
                    {
                        int index = snowyList.FindIndex(p => p.Pokemon == item.Pokemon);
                        snowyList[index].Count += item.Count;
                    }
                }
            }
            snowyList = snowyList.OrderByDescending(i => i.Count).ToList();

        }
    }
}