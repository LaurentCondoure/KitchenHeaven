using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.DataObject.Enums;

namespace KitchenHeaven.FrameWork.DataAccess.Factories
{
    public interface IAPIAcessFactory
    {
        IMealAPIAccess CreateAPIAccess(FilterType filterType);
    }
}
