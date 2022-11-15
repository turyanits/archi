//Варіант 5.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBuilder builder = new Builder();
            HtmlPart htmlpart = builder
                                .SetName("Actions")
                                .SetDateStemp()
                                .AddAction("Action One")
                                .AddAction("Description one")
                                .AddAction("Url one")
                                .SetDateStemp()
                                .AddAction("Action Two")
                                .AddAction("Description two")
                                .AddAction("Url two")
                                .SetDateStemp()
                                .AddAction("Action Three")
                                .AddAction("Description three")
                                .AddAction("Url three")
                                .GetHtmlPart();
            Console.WriteLine(htmlpart.ToString());
            Director director = new Director(builder);
            Console.WriteLine(director.Header("User's text").ToString());
            Console.WriteLine(director.MainPart().ToString());
            Console.WriteLine(director.Announcement().ToString());
            Console.WriteLine(director.Footer().ToString());

        }
    }
    class HtmlPart
    {
        private List<object> parts = new List<object>();
        public string Name = "No name";
        public void Add(string part)
        {
            this.parts.Add(part);
        }

        public override string ToString()
        {
            string str = string.Empty;
            foreach (string part in this.parts)
            {
                str += $"\t{part}\n ";
            }
            return $"{this.Name}\n {str}";
        }
    }

    interface IBuilder
    {
        IBuilder AddAction(object part);
        IBuilder SetDateStemp();
        IBuilder SetName(string name);
        HtmlPart GetHtmlPart();
        void Reset();
    }

    class Builder : IBuilder
    {
        protected HtmlPart product = new HtmlPart();

        public void Reset()
        {
            this.product = new HtmlPart();
        }
        public IBuilder SetName(string name)
        {
            this.product.Name = name;
            return this;

        }

        public IBuilder AddAction(object part)
        {
            this.product.Add(part as string);
            return this;
        }

        public virtual IBuilder SetDateStemp()
        {
            this.product.Add($"Date stemp: {DateTime.Now.ToString()}");
            return this;
        }

        public HtmlPart GetHtmlPart()
        {
            HtmlPart result = this.product;
            this.Reset();
            return result;
        }
    }
    class Director
    {
        public IBuilder builder;
        public Director(IBuilder builder)
        {
            this.builder = builder;
        }

        public HtmlPart Header(string part)
        {
            this.builder.Reset();
            return this.builder
                    .SetName("Header")
                    .AddAction(part)
                    .AddAction("Description one")
                    .AddAction("Description two")
                    .AddAction("Description three")
                    .GetHtmlPart();
        }
        public HtmlPart MainPart()
        {
            this.builder.Reset();
            return this.builder
                    .SetName("Main part")
                    .SetDateStemp()
                    .AddAction("Action One")
                    .AddAction("Description one")
                    .AddAction("Url one")
                    .SetDateStemp()
                    .AddAction("Action Two")
                    .AddAction("Description two")
                    .AddAction("Url two")
                    .SetDateStemp()
                    .AddAction("Action Three")
                    .AddAction("Description three")
                    .AddAction("Url three")
                    .GetHtmlPart();
        }
        public HtmlPart Announcement()
        {
            this.builder.Reset();
            return this.builder
                    .SetName("Announcement")
                    .AddAction("Action One")
                    .AddAction("Action Two")
                    .AddAction("Action Three")
                    .GetHtmlPart();
        }
        public HtmlPart Footer()
        {
            this.builder.Reset();
            return this.builder
                    .SetName("Footer")
                    .AddAction("Copyright 2022, UZNHU")
                    .GetHtmlPart();
        }
    }
}
