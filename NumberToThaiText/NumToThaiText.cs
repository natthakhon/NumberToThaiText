using System;
using System.Activities;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToThaiText
{
    public class NumToThaiText : CodeActivity
    {
        [Category("Input")]
        [RequiredArgument]
        public InArgument<decimal> Number { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<bool> HasBahtSuffix { get; set; }

        [Category("Input")]
        [RequiredArgument]
        public InArgument<bool> HasSatangSuffix { get; set; }

        [Category("Output")]
        public OutArgument<string> ThaiIntegerText { get; set; }

        [Category("Output")]
        public OutArgument<string> ThaiDecimalText { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var converter = new NumToThaiTextConverter().Convert(Number.Get(context).ToString()
                , Boolean.Parse(HasBahtSuffix.Get(context).ToString())
                , Boolean.Parse(HasSatangSuffix.Get(context).ToString()));           

            ThaiIntegerText.Set(context, converter.Interger);
            ThaiDecimalText.Set(context, converter.Satang);
        }
    }
}
