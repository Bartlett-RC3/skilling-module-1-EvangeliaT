using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using SpatialSlur;

namespace RC3
{
    /// <summary>
    /// 
    /// </summary>
    public class ModelManager : MonoBehaviour
    {
        [SerializeField] private ModelInitializer _initializer;
        [SerializeField] private Cell _cellPrefab;
        [SerializeField] private int _countX = 10;
        [SerializeField] private int _countY = 10;

        private Cell[,] _cells;
        private GameOfLife2D _model;
        private int _stepCount;

        // declare my variables
        private int[] _cellAges;
        private int index;
        private int[,] _thisState;
        private float _layerDensity;
        private List<float> _layerDensityList;

        // declare coroutine
        IEnumerator changeColCoroutine;

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            // initialize my data structures
            _thisState = new int[_countY, _countX];
            _cellAges = new int[_countY * _countX];
            _layerDensityList = new List<float>();

            // create cell array
            _cells = new Cell[_countY, _countX];

            // instantiate cell prefabs and store in array
            for (int y = 0; y < _countY; y++)
            {
                for (int x = 0; x < _countX; x++)
                {
                    Cell cell = Instantiate(_cellPrefab, transform);
                    cell.transform.localPosition = new Vector3(x, y, 0);
                    _cells[y, x] = cell;
                }
            }

            // create model
            _model = new GameOfLife2D(_countY, _countX);

            // initialize model
            _initializer.Initialize(_model.CurrentState);

            //call coroutine
            changeColCoroutine = ChangeColorPerTime();
            StartCoroutine(changeColCoroutine);

            if (Time.time > 1)
            {
                StopCoroutine(changeColCoroutine);
                StopAllCoroutines();
            }

        }


        /// <summary>
        /// 
        /// </summary>
        private void Update()
        {
            _model.Step();
            _stepCount++;

            int[,] state = _model.CurrentState;

            // update cells based on current state of model
            for (int y = 0; y < _countY; y++)
            {
                for (int x = 0; x < _countX; x++)
                    _cells[y, x].State = state[y, x];
                

                // call the function that calculates the density of different frames
                _layerDensity = CalculateDensity(_countY, _countX);

                // store the density of different frames in a list
                _layerDensityList.Add(_layerDensity);

                // call the function that calculates and stores the age of the cells
                CalculateCellAges();
            }
        }

            // Calculate the density of different frames
            private float CalculateDensity(int countY, int CountX)
            {
                int aliveCount = 0;

                for (int i = 0; i < countY; i++)
                {
                    for (int j = 0; j < CountX; j++)
                    {
                        aliveCount += _cells[i, j].State;
                    }
                }
                return (float)aliveCount / _cells.Length;
            }

            
            // Store the ages of the cells in an array _cellAges
            private void CalculateCellAges()
            {
            int[,]_thisState = new int[_countY, _countX];

            index = 0;
                 
                 for (int i = 0; i < _countY; i++)
                {
                    for (int j = 0; j < _countX; j++)
                    {
                    _thisState[i, j] = _cells[i, j].State;

                        if (_thisState[i, j] == 1)
                        {
                            _cellAges[index]++;
                        }
                        else
                        {
                            _cellAges[index] = 0;
                        }
                        index++;
                    }
                }
            }

           // coroutine that changes the colour of cells according to time cells are alive
             IEnumerator ChangeColorPerTime()
            {
                while (true)
                {
                index = 0;
                foreach (var cell in _cells)
                    {
                   
                    if (_cellAges[index] <= 1)
                    {
                        cell.GetComponent<MeshRenderer>().material.color = Color.cyan;
                    }
                    else if (_cellAges[index]>1 && _cellAges[index] <= 10)
                    {
                        cell.GetComponent<MeshRenderer>().material.color = Color.gray;
                    }
                    else
                    {
                        cell.GetComponent<MeshRenderer>().material.color = Color.black;
                    }
                    index++;
                    }
                    yield return new WaitForSeconds(1);
                }
            }

        }
    }

