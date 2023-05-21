using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Exam
{
    public class Perfumery
    {
        private readonly List<Perfume> perfumes = new List<Perfume>();
        private string name;

        public Perfumery(string name)
        {
            this.Name = name;
        }

        public string Name 
        { 
            get => this.name;
            private set
            {
                if (value == null || value.Length < 6) throw new ArgumentException("Invalid perfumery name!");
                this.name = value;
            }
        }

        public void AddPerfume(Perfume perfume)
        {
            if (perfume == null) return;
            this.perfumes.Add(perfume);
        }

        public bool SellPerfume(Perfume perfume)
        {
            if (perfume == null) return false;

            int perfumeIndex = this.perfumes.FindIndex(p => p.Brand == perfume.Brand && p.Price == perfume.Price);
            if (perfumeIndex == -1) return false;

            this.perfumes.RemoveAt(perfumeIndex);
            return true;
        }

        public double CalculateTotalPrice() => this.perfumes.Sum(p => p.Price);

        public Perfume GetPerfumeWithHighestPrice()
        {
            if (this.perfumes.Count == 0) return null;

            int maxIndex = 0;
            for (int i = 1; i < this.perfumes.Count; i++)
            {
                if (this.perfumes[i].Price > this.perfumes[maxIndex].Price)
                    maxIndex = i;
            }

            return this.perfumes[maxIndex];
        }

        public Perfume GetPerfumeWithLowestPrice()
        {
            if (this.perfumes.Count == 0) return null;

            int minIndex = 0;
            for (int i = 1; i < this.perfumes.Count; i++)
            {
                if (this.perfumes[i].Price < this.perfumes[minIndex].Price)
                    minIndex = i;
            }

            return this.perfumes[minIndex];
        }

        public void RenamePerfumery(string newName) => this.Name = newName;

        public void SellAllPerfumes() => this.perfumes.Clear();

        public override string ToString()
        {
            if (this.perfumes.Count == 0) return $"Perfumery {this.Name} has no available perfumes.";

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Perfumery {this.Name} has {this.perfumes.Count} perfume/s:");
            foreach (var perfume in this.perfumes)
                sb.AppendLine(perfume.ToString());
            return sb.ToString().Trim();
        }
    }
}
