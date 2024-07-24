﻿using Demo.Domain.Abstractions;

namespace Demo.Domain.ValueObjects
{
    public class MenuId : ValueObject
    {
        public Guid Value { get; }
        private MenuId(Guid value)
        {
            Value = value;
        }

        public static MenuId Of(Guid value)
        {
            return new MenuId(value);
        }

        public override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }

    //public class MenuId : AggregateRootId<Guid>
    //{
    //    public override Guid Value { get; protected set; }
    //    private MenuId(Guid value)
    //    {
    //        Value = value;
    //    }

    //    public static MenuId Of(Guid value)
    //    {
    //        return new MenuId(value);
    //    }

    //    public override IEnumerable<object> GetEqualityComponents()
    //    {
    //        yield return Value;
    //    }
    //}
}
