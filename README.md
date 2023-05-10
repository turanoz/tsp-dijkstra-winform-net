# Travelling Salesman Problem Solver with Dijkstra's Algorithm

## Introduction

This project provides a graphical user interface for understanding and visualizing the solution of the Travelling Salesman Problem (TSP) using Dijkstra's Algorithm. It's designed to make the abstract concepts of these algorithms more tangible and intuitive.

The project includes a visual representation of a graph, where nodes and paths can be manually added by the user. It allows for real-time interaction, dynamically updating the weight of paths and recalculating the optimal route based on the changes.

## Features

1. **Interactive Graph Creation**: Manually add nodes and paths on the graphical user interface. This provides a flexible way to construct different scenarios for the TSP.
2. **Dynamic Path Weight Adjustment**: The weight of paths, representing the cost or distance between nodes, can be dynamically updated, allowing for real-time modifications of the graph.
3. **Visualisation of Dijkstra's Algorithm**: The project visually demonstrates the operation of Dijkstra's Algorithm step by step, showing how it explores different paths and eventually finds the shortest path.

## Usage

1. **Add Nodes**: Click on the interface to add nodes. The first node will be colored orange and the rest will be red. Each node is labeled with a unique ID.
2. **Add Paths**: After adding nodes, you can switch to the mode to add paths. Paths are drawn by clicking on the first node and then on the second node. 
3. **Update Path Weights**: You can also update the weight of paths by clicking on them and entering a new value.
4. **Solve TSP**: Once your graph is set up, press the solve button to visualize the solution of the TSP using Dijkstra's Algorithm.

## Requirements and Installation

The project is developed in C# and requires .NET 6.0 or above. You can clone the repository and open the solution file in Visual Studio to run the application.

## Conclusion

This project is an excellent learning tool for those studying computer science, specifically algorithms and graph theory. It's also a practical tool for those who want to solve TSP in various applications.

Please feel free to contribute and enhance the features of this application. Happy coding!