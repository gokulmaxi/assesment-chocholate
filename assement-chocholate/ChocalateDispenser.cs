using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace assement_chocholate
{

    enum ChocolateColor
    {
        green,
        silver,
        blue,
        crimson,
        purple,
        red,
        pink
    }
    class Chocalate
    {
        public ChocolateColor Color;
        public Chocalate(ChocolateColor color)
        {
            Color = color;
        }
    }
    internal class ChocalateDispenser
    {
        Chocalate[] chocalates;
        List<Chocalate> chocalateList;
        public ChocalateDispenser(Chocalate[] ch) { 
            chocalateList = ch.ToList();
        }
        public void addChocolates(ChocolateColor color,int count) {
        for (int i = 0; i < count; i++)
            {
                chocalateList.Add(new Chocalate(color));
            }
        }
        public void Chocalates(int count)
        {
            if (chocalateList.Count>count)
            {
                chocalateList.RemoveRange(chocalateList.Count - count, count);
            }
        }
        public Chocalate[] dispenseChocalates(int count) {
            Chocalate[] dispensedChoclates = new Chocalate[count];
            if (chocalateList.Count>count)
            {
                for(int i = 0; i < count; i++)
                {
                    dispensedChoclates[i] = chocalateList[i];
                }
                chocalateList.RemoveRange(0, count);
            }
            return dispensedChoclates;
        }
        public Chocalate[] dispenseChocalatesByColor(ChocolateColor color,int count) {
            List<Chocalate> dispencseChocoList = new List<Chocalate>();
            int dispeseCount =0;
            foreach (Chocalate ch in chocalateList)
            {
                if (count == dispeseCount) break;
                if (ch.Color == color)
                {
                    dispencseChocoList.Add(ch);
                    chocalateList.Remove(ch);
                    count++;
                }
            }
            return dispencseChocoList.ToArray();
        }
        public int[] noOfChocolates()
        {
            int[] ColourCount = new int[7];

            //iterate over enum
            foreach(ChocolateColor col in Enum.GetValues(typeof(ChocolateColor)))
            {
                //aggregate all chocolate by color
                List<Chocalate> chocalatesByColor = chocalateList.FindAll(ch => ch.Color==col);
                ColourCount[(int)col]= chocalatesByColor.Count;
            }
            return ColourCount;
        }
        

    }
}
