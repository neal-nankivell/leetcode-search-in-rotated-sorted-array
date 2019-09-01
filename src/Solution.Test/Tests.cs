using AutoFixture;
using NUnit.Framework;

namespace Solution.Test
{
    public class NaiveSolutionTests : GenericSolutionTests<NaiveSolution> { }
    public class ImprovedSolutionTests : GenericSolutionTests<ImprovedSolution> { }

    /// <summary>
    /// As we expect to iterate on solutions to the same kata/problem,
    /// We should only need to write the unit tests once, then run the same tests for each solution
    /// </summary>
    /// <typeparam name="T">The implmentation type</ref></typeparam>
    public abstract class GenericSolutionTests<T> where T : ISolution
    {
        private ISolution _sut = new Fixture().Create<T>();

        public int Search(int[] nums, int target) => _sut.Search(nums, target);
    }
}