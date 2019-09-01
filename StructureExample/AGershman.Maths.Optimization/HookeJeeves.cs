using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AGershman.Maths.Optimization
{
    /// <summary>
    /// Simplified Hooke and Jeeves approach implementation
    /// </summary>
    public static class HookeJeeves
    {
        /// <summary>
        /// Multiargumental local minimum search using simplified Hooke-Jeeves approach
        /// </summary>
        /// <param name="goal">Goal function</param>
        /// <param name="minParams">Minimum values of the function arguments</param>
        /// <param name="maxParams">Maximum values of the function arguments</param>
        /// <param name="startParams">Start values of the function arguments</param>
        /// <param name="startStep">Hooke-Jeeves initial step</param>
        /// <param name="endStep">Hooke-Jeeves end step</param>
        /// <param name="stepDivider">Hooke-Jeeves step divider</param>
        /// <param name="goalThres">Goal function values threshold to exclude chattering</param>
        /// <returns>Local optimum arguments array</returns>
        public static double[] FindOptimum(GoalFunction goal, 
            double[] minParams, double[] maxParams, double[] startParams,
            double startStep, double endStep, double stepDivider, double goalThres)
        {
            int n = minParams.Length;

#if DEBUG
            // In release it should be excluded to avoid overhead

            if (maxParams.Length != n || startParams.Length != n)
            {
                // parameter arrays have different length
                throw new ArgumentException();
            }

            if (Enumerable.Range(0, n).Any(i => startParams[i] < minParams[i] || startParams[i] > maxParams[i]))
                // start parameters are out of search range
                throw new ArgumentOutOfRangeException();

            if (startStep <= 0 || endStep <= 0 || stepDivider <= 0)
                // incorrect step values
                throw new ArgumentOutOfRangeException();
#endif

            // initial function arguments
            double[] vector = new double[n];
            Array.Copy(startParams, vector, n);

            // initial function value
            double goalCur = goal(vector);
            double goalMin = goalCur;

            // initial step value
            double step = startStep;

            // search direction array
            int[] dir = new int[n];

            while (step >= endStep)
            {
                #region Exploration phase

                for (int i = 0; i < n; i++)
                {
                    dir[i] = 0;
                    vector[i] = vector[i] - step;

                    if (vector[i] < minParams[i])
                        goalCur = double.MaxValue;
                    else
                        goalCur = goal(vector);

                    if (goalCur < goalMin * (1 - goalThres))
                    {
                        dir[i] = -1;
                        goalMin = goalCur;
                    }
                    else
                    {
                        vector[i] = vector[i] + 2 * step;

                        if (vector[i] > maxParams[i])
                            goalCur = double.MaxValue;
                        else
                            goalCur = goal(vector);

                        if (goalCur < goalMin * (1 - goalThres))
                        {
                            dir[i] = 1;
                            goalMin = goalCur;
                        }
                        else
                        {
                            vector[i] = vector[i] - step;
                            dir[i] = 0;
                        }
                    }
                }

                #endregion

                #region Pattern phase

                bool firstTime = true;
                while (true)
                {
                    if (dir.All(d => d == 0))
                    {
                        step /= stepDivider;
                        break;
                    }

                    for (int i = 0; i < n; i++)
                    {
                        double prm = vector[i] + step * dir[i];
                        if (prm < minParams[i] || prm > maxParams[i])
                            dir[i] = 0;
                        else
                            vector[i] = prm;
                    }

                    goalCur = goal(vector);
                    if (goalCur < goalMin * (1 - goalThres))
                    {
                        goalMin = goalCur;
                        firstTime = false;
                    }
                    else
                    {
                        for (int i = 0; i < n; i++)
                            vector[i] = vector[i] - step * dir[i];
                        if (firstTime)
                            step /= stepDivider;
                        break;
                    }
                }

                #endregion
            }

            return vector;
        }
    }
}
