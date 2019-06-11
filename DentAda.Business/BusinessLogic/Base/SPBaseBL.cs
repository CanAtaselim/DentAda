using DentAda.Data.Model;


namespace DentAda.Business.BusinessLogic.Base
{
    public class SPBaseBL
    {
        private DentAdaEntities _entityForSP;

        protected DentAdaEntities EntityForSP
        {
            get { return _entityForSP == null ? _entityForSP = new DentAda.Data.Model.DentAdaEntities(ConnectionStrings.DentAda_Prod) : _entityForSP; }
        }
       
    }
}
