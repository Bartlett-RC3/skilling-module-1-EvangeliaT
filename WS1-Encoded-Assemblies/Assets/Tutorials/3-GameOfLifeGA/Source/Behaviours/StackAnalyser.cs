using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using SpatialSlur;

namespace RC3
{
    namespace WS2
    {
        /// <summary>
        /// 
        /// </summary>
        [RequireComponent(typeof(StackModel))]
        public class StackAnalyser : MonoBehaviour
        {
            private StackModel _model;
            private float _densitySum;
            private int _currentLayer; // index of the most recently analysed layer

            private int _modelCurrentLayer;
            private float _stablePercentage;

            private float _patternPercentage;

            //bool patternUpdated = false;


            /// <summary>
            /// 
            /// </summary>
            private void Start()
            {
                _model = GetComponent<StackModel>();
                ResetAnalysis();

                // Moved to create
                /*
                _columnCount = _model.Stack.ColumnCount;
                _rowCount = _model.Stack.RowCount;
                _layerCount = _model.Stack.LayerCount;
                //_modelCurrentLayer = _model.CurrentLayer;
                
                cellStates = new int[_rowCount, _columnCount, _layerCount];
*/
            }


            /// <summary>
            /// 
            /// </summary>
            private void LateUpdate()
            {
                // reset analysis if necessary
                if (_currentLayer > _model.CurrentLayer)
                    ResetAnalysis();

                // update analysis if model has been updated
                if (_currentLayer < _model.CurrentLayer)
                    UpdateAnalysis();
            }


            /// <summary>
            /// Returns the current mean density of the stack
            /// </summary>
            public float MeanStackDensity
            {
                get { return _densitySum / (_model.CurrentLayer + 1); }
            }


            /// <summary>
            /// 
            /// </summary>
            public void UpdateAnalysis()
            {
                int currentLayer = _model.CurrentLayer;
                CellLayer layer = _model.Stack.Layers[currentLayer];
                //Debug.Log("I am at layer " + _currentLayer);

                //update layer current density
                var density = CalculateDensity(layer);
                layer.Density = density;
                _densitySum += density; // add to running sum



                if (_currentLayer == (_model.Stack.LayerCount - 2))
                {
                    //Debug.Log("I will update the patterns");

                    //Debug.Log("I updated the patterns");
                    AnalyzePatterns();
                    //patternUpdated = true;

                }


                //Debug.Log("stable patterns number is : " + stab.ToString());

                _currentLayer = currentLayer;
            }



            /// <summary>
            /// 
            /// </summary>
            private void OnStackComplete()
            {
                // Perform any calculations on the completed stack
                AnalyzePatterns();
                //...
                //...
                //...
                //...
            }



            /// <summary>
            /// 
            /// </summary>
            public void AnalyzePatterns()
            {
                int aliveCount;
                var cellStates = CreateCellStatesArray(out aliveCount);

                int stableCount = CountStablePatterns(cellStates);
                _stablePercentage = ((float)stableCount) / ((float)cellStates.Length);


                int sumOfOurPattern = FindOurPattern(cellStates);
                _patternPercentage = (float)sumOfOurPattern / ((float)cellStates.Length);
                //Debug.Log("total count of our pattern is: " + sumOfOurPattern);


                //Debug.Log("stable percentage is : " + _stablePercentage.ToString());
            }


            /// <summary>
            ///
            /// </summary>
            private int[,,] CreateCellStatesArray(out int aliveCount)
            {
                var stack = _model.Stack;
                var cellStates = new int[stack.ColumnCount, stack.RowCount, stack.LayerCount];
                aliveCount = 0;

                // iterate over all layers in the current stack
                for (int i = 0; i < stack.LayerCount; i++)
                {
                    Cell[,] cells = stack.Layers[i].Cells;

                    // iterate over all cells in the current layer
                    for (int j = 0; j < stack.ColumnCount; j++)
                    {
                        for (int k = 0; k < stack.RowCount; k++)
                        {
                            int state = cells[j, k].State;

                            //Debug.Log(" I am at the cell : " + i + j + k);
                            cellStates[j, k, i] = state; // assign state

                            //Debug.Log("I set the state: " + cellStates[j, k, i].ToString());

                            if (state == 1)
                                aliveCount++;
                        }
                    }
                }

                return cellStates;
            }

            /*

            /// <summary>
            /// 
            /// </summary>
            private List<int[]> CollectPatterns(int[,,] cellStates)
            {
                List<int[]> neighbs = new List<int[]>();

                for (int i = 0; i < cellStates.GetLength(0); i++)
                {
                    // exclude first and last, so that all the patterns have 9 cells
                    for (int j = 1; j < cellStates.GetLength(1) - 1; j++)
                    {
                        // exclude first and last, so that all the patterns have 9 cells
                        for (int k = 1; k < cellStates.GetLength(2) - 1; k++)
                        {
                            // check only the alive cells
                            if (cellStates[i,j,k] == 1)
                            {
                                var neighb = new int[9];
                                int index = 0;

                                // TODO try to avoid deeply nested loops like this - move the ones below into a separate function

                                //store the 9 cell patterns placing the index at the center
                                for (int l = k - 1; l < k + 2; l++)
                                {
                                    for (int m = j - 1; m < j + 2; m++)
                                        neighb[index++] = cellStates[i, l, m];
                                }

                                //Create my Single list of patterns arrays
                                neighbs.Add(neighb);
                            }
                        }
                    }
                }

                return neighbs;
            }


            /// <summary>
            /// Returns the number of stable patterns in the 
            /// </summary>
            private int CountStablePatterns(List<int[]> patterns)
            {
                int result = 0;

                foreach (int[] pattern in patterns)
                {
                    int aliveCount = 0;

                    for (int i = 0; i < pattern.Length; i++)
                        if (pattern[i] == 1) aliveCount++;

                    if (aliveCount == 4)
                        result++;
                }

                return result;
            }

            */

            /// <summary>
            /// 
            /// </summary>
            private int CountStablePatterns(int[,,] cellStates)
            {
                int stableCount = 0;

                //Debug.Log("number of layers is: " + cellStates.GetLength(0).ToString());

                for (int i = 0; i < cellStates.GetLength(2); i++)
                {
                    // exclude first and last, so that all the patterns have 9 cells
                    for (int j = 1; j < cellStates.GetLength(0) - 1; j++)
                    {
                        // exclude first and last, so that all the patterns have 9 cells
                        for (int k = 1; k < cellStates.GetLength(1) - 1; k++)
                        {
                            //Debug.Log("I am at the cell:" + i + " " + j + " " + k);

                            // check only the alive cells
                            if (cellStates[j, k, i] == 1)
                            {
                                //Debug.Log("I am inside if");
                                int aliveCount = 0;

                                // TODO try to avoid deeply nested loops like this - move the ones below into a separate function

                                // add up alive cells in the 9 cell neighborhood centered on (j, k)
                                for (int l = k - 1; l < k + 2; l++)
                                {
                                    for (int m = j - 1; m < j + 2; m++)
                                        if (cellStates[m, l, i] == 1) aliveCount++;
                                }

                                if (aliveCount == 4)
                                    stableCount++;
                            }
                        }
                    }
                }

                return stableCount;
            }


            /// <summary>
            /// Finds our pattern.
            /// </summary>
            /// <returns>The our pattern.</returns>
            /// <param name="cellStates">Cell states.</param>
            int FindOurPattern(int[,,] cellStates)
            {
                int sumOfOurPattern = 0;

                //Debug.Log("number of layers is: " + cellStates.GetLength(0).ToString());

                for (int i = 0; i < cellStates.GetLength(2); i++)
                {
                    // exclude first and last, so that all the patterns have 9 cells
                    for (int j = 1; j < cellStates.GetLength(0) - 1; j++)
                    {
                        // exclude first and last, so that all the patterns have 9 cells
                        for (int k = 1; k < cellStates.GetLength(1) - 1; k++)
                        {
                            //Debug.Log("I am at the cell:" + i + " " + j + " " + k);

                            // check only the alive cells
                            if (cellStates[j, k, i] == 1)
                            {
                                if(cellStates[j-1,k+1,i]==0 && cellStates[j+1,k+1,i]==0 && cellStates[j-1,k-1,i]==0 && cellStates[j+1,k-1,i]==0)
                                {
                                    if (cellStates[j,k-1,i]==1 && cellStates[j+1,k,i]==1 && cellStates[j-1,k,i]==1 && cellStates[j,k+1,i]==1)
                                    {
                                        sumOfOurPattern++;
                                    }
                                }

                            }
                        }
                    }
                }

                return sumOfOurPattern;
            }




            /// <summary>
            /// Calculate the density of alive cells for the given layer
            /// </summary>
            /// <returns></returns>
            private float CalculateDensity(CellLayer layer)
            {
                var cells = layer.Cells;
                int aliveCount = 0;

                foreach (var cell in cells)
                    aliveCount += cell.State;

                return (float)aliveCount / cells.Length;
            }


            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private void ResetAnalysis()
            {
                _densitySum = 0.0f;
                _currentLayer = -1;
            }

            /// <summary>
            /// 
            /// </summary>
            public void Fitness()
            {
                float fitness = 1;

                //calculate separate objective fitness values
                float structuralFit = StructuralFitness();
                float massFit = MassFitness();

                //setup fitness function to combine and weight these factors
                //fitness = (structuralFit + massFit) / 2;

                fitness = PatternFitness();
                //fitness = MeanStackDensity;

                //set stack fitness value
                _model.Stack.SetFitness(fitness);
                Debug.Log("Fitness " + fitness);
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private float PatternFitness()
            {
                //Debug.Log("stable patterns number is : " + _stablePatterns.Count.ToString() + " and all patterns number is : " + _allPatternSingle.Count.ToString());

                //float patternFitness = _stablePercentage; //((float)_stablePatterns.Count)/_allPatternSingle.Count;

                //float patternFitness = _patternPercentage;

                float patternFitness = (_patternPercentage + _stablePercentage)/2;

                //Debug.Log("patternFitness is: " + patternFitness);

                return patternFitness;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private float DensityFitness()
            {
                float densityFitness = 1;
                //calculate assign density fitness value

                return densityFitness;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private float MassFitness()
            {
                float massFitness = 1;
                //calculate overall mass - assign fitness value

                return massFitness;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            private float StructuralFitness()
            {
                float structuralFitness = 1;
                //calculate structural forces and return fitness value
                return structuralFitness;
            }
        }
    }
}
