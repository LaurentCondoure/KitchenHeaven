using KitchenHeaven.FrameWork.DataAccess.Interfaces;
using KitchenHeaven.FrameWork.Entities.Enums;

namespace KitchenHeaven.FrameWork.DataAccess.Factories
{
    public interface IAPIAcessFactory
    {
        IMealAPIAccess CreateAPIAccess(FilterType filterType);
    }
}
