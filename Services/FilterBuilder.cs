using System.Collections.Generic;
using System.IO;
using PhaseSnapshotCreator.Services;
using Tekla.Structures.Filtering;
using Tekla.Structures.Filtering.Categories;

namespace PhaseSnapshotCreator.Filtering
{
    public class FilterBuilder
    {
        internal static void CreateFilter(string filterName, List<int> phasesToShow)
        {
            var collection = new BinaryFilterExpressionCollection();

            foreach (var phase in phasesToShow)
            {
                var phaseExpression = new StringConstantFilterExpression(phase.ToString());

                var phaseFilter = new BinaryFilterExpression(new AssemblyFilterExpressions.Phase(), StringOperatorType.IS_EQUAL, phaseExpression);

                collection.Add(new BinaryFilterExpressionItem(phaseFilter, BinaryFilterOperatorType.BOOLEAN_OR));
            }

            var filter = new Filter(collection);

            var path = Path.Combine(TeklaService.ModelPath, "attributes", filterName);

            filter.CreateFile(FilterExpressionFileType.OBJECT_GROUP_VIEW, path);
        }
    }
}
