using System;
using System.Reflection;
using FizzWare.NBuilder;
using FizzWare.NBuilder.Implementation;
using FizzWare.NBuilder.PropertyNaming;

namespace Testing.Toolkit.Core.Data
{
    public class SqlValuePropertyNamer : RandomValuePropertyNamer
    {
        private readonly IRandomGenerator _generator;
        public static DateTime MinDateTime = new DateTime(1753, 1, 1);
        public static DateTime MaxDateTime = new DateTime(9999, 12, 31);

        public SqlValuePropertyNamer() : this(new RandomGenerator()) {}

        public SqlValuePropertyNamer(IRandomGenerator generator)
            : base(generator, new ReflectionUtil(), true, MinDateTime, MaxDateTime, true)
        {
            _generator = generator;
        }

        protected override decimal GetDecimal(MemberInfo memberInfo)
        {
            return Math.Round(_generator.Next(new decimal(0), new decimal(200000)), 2);
        }

        protected override DateTime GetDateTime(MemberInfo memberInfo)
        {
            var datetime = base.GetDateTime(memberInfo);

            return datetime.Date;
        }

        protected override string GetString(MemberInfo memberInfo)
        {
            var value = base.GetString(memberInfo);
            if(value.Length > 10)
                value = value.Substring(0, 10);

            return value;
        }
    }
}
