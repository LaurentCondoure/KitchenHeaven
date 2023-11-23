using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Enums;

namespace KitchenHeaven.FrameWork.DataAccess.Factories
{
    public interface IAPIAccessFactory
    {
        IMealAPIAccess CreateAPIAccess(FilterType filterType);
    }
}
