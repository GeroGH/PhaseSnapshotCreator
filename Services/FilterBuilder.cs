using System.IO;
using PhaseSnapshotCreator.Services;
using Tekla.Structures.Filtering;
using Tekla.Structures.Filtering.Categories;

namespace PhaseSnapshotCreator.Filtering
{
    public class FilterBuilder
    {

        public static void CreateFilter(string filterName, string CurrentPhases, string VisiblePhases)
        {
            var CurrentPhasesExpresions = new StringConstantFilterExpression(CurrentPhases);
            var CurrentPhasesBinaryExpresions = new BinaryFilterExpression(new AssemblyFilterExpressions.Phase(), StringOperatorType.IS_EQUAL, CurrentPhasesExpresions);

            var VisiblePhasesExpresions = new StringConstantFilterExpression(VisiblePhases);
            var VisiblePhasesBinaryExpresions = new BinaryFilterExpression(new AssemblyFilterExpressions.Phase(), StringOperatorType.IS_EQUAL, VisiblePhasesExpresions);

            var collection = new BinaryFilterExpressionCollection();
            var item1 = new BinaryFilterExpressionItem(CurrentPhasesBinaryExpresions, BinaryFilterOperatorType.BOOLEAN_OR);
            collection.Add(item1);
            var item2 = new BinaryFilterExpressionItem(VisiblePhasesBinaryExpresions, BinaryFilterOperatorType.BOOLEAN_OR);
            collection.Add(item2);

            var filter = new Filter(collection);
            var path = Path.Combine(TeklaService.ModelPath, "attributes", filterName);
            filter.CreateFile(FilterExpressionFileType.OBJECT_GROUP_VIEW, path);
        }
    }
}
