
namespace OBALog.Business
{
    public class BL_OrganisationSubCategory
    {

        public System.Data.DataTable selectByCategory(Model.ML_OrganisationSubCategory Category)
        {
            return new OBALog.Data.DL_OrganisationSubCategory().selectByCategory(Category);
        }

        public bool delete(Model.ML_OrganisationSubCategory Category)
        {
            return new OBALog.Data.DL_OrganisationSubCategory().delete(Category);
        }

        public int selectUsage(Model.ML_OrganisationSubCategory Category)
        {
            return new OBALog.Data.DL_OrganisationSubCategory().selectUsage(Category);
        }

        public bool update(Model.ML_OrganisationSubCategory Category)
        {
            return new OBALog.Data.DL_OrganisationSubCategory().update(Category);
        }

        public int insert(Model.ML_OrganisationSubCategory Category)
        {
            return new OBALog.Data.DL_OrganisationSubCategory().insert(Category);
        }

        public bool deleteByCategory(Model.ML_OrganisationSubCategory Category)
        {
            return new OBALog.Data.DL_OrganisationSubCategory().deleteByCategory(Category);
        }

        public System.Data.DataTable select(Model.ML_OrganisationSubCategory Category)
        {
            return new OBALog.Data.DL_OrganisationSubCategory().select(Category);
        }
    }
}
