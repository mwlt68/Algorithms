# Algorithms

## 🚀 Heap Sort Visualize

Heap Sort is a popular and efficient sorting algorithm in computer programming. Learning how to write the heap sort algorithm requires knowledge of two types of data structures - arrays and trees.
[Click](https://www.programiz.com/dsa/heap-sort) to see the algorithm in more detail.

If we examine the picture below, we enter our numbers in the first form that opens, separating them with commas. Click the "Create Tree" button.
The numbers entered on the opened form are visualized in tree form. Some information about the algorithm is seen step by step.
In the last step, our numbers are seen in order. [Click](https://vimeo.com/569417709) to watch the preview video.

<div>
<img src="Read Me Images/2.png" >
<img src="Read Me Images/3.png" >
</div>


## 🚀 Huffman

Huffman Coding is a technique of compressing data to reduce its size without losing any of the details. 
It was first developed by David Huffman.  Huffman Coding is generally useful to compress the data in which there are frequently occurring characters.

In the picture below, we see the output that the algorithm will give us when we write the "bcaadddccacacac" value as a parameter to the console. 
You can visit the [link](https://www.programiz.com/dsa/huffman-coding) to understand this example in more detail.

<div>
<img src="Read Me Images/1.png" >
</div>


## 🚀 Kruskal And Prim

A console application in which Kruskal and Prim algorithms are applied together is coded. Here, "peak value", "target value" and "distance value" are taken as parameters. It returns their result.

### Prim

Prim's algorithm is a minimum spanning tree algorithm that takes a graph as input and finds the subset of the edges of that graph which
- form a tree that includes every vertex
- has the minimum sum of weights among all the trees that can be formed from the graph

[Click](https://www.programiz.com/dsa/prim-algorithm) to see the algorithm in more detail.

### Kruskal
It falls under a class of algorithms called greedy algorithms that find the local optimum in the hopes of finding a global optimum.

We start from the edges with the lowest weight and keep adding edges until we reach our goal.

The steps for implementing Kruskal's algorithm are as follows:

1- Sort all the edges from low weight to high

2- Take the edge with the lowest weight and add it to the spanning tree. If adding the edge created a cycle, then reject this edge.

3- Keep adding edges until we reach all vertices.

[Click](https://www.programiz.com/dsa/kruskal-algorithm) to see the algorithm in more detail.


## 🚀 LZW

(Lempel–Ziv–Welch) Compression technique
There are two categories of compression techniques, lossy and lossless. Whilst each uses different techniques to compress files, both have the same aim: To look for duplicate data in the graphic (GIF for LZW) and use a much more compact data representation. Lossless compression reduces bits by identifying and eliminating statistical redundancy. No information is lost in lossless compression. On the other hand, Lossy compression reduces bits by removing unnecessary or less important information.

[Click](https://www.geeksforgeeks.org/lzw-lempel-ziv-welch-compression-technique/) to see the algorithm in more detail.

The program first expects a string expression. For example, when given the expression "BABAABAAA". It produces the output in the picture given below. Here is the order of the index values and the string expression kept in the index value.
<div>
<img src="Read Me Images/4.png" >
</div>

## 🚀Dijkstra  Visualize

Dijkstra's algorithm allows us to find the shortest path between any two vertices of a graph.
It differs from the minimum spanning tree because the shortest distance between two vertices might not include all the vertices of the graph.

[Click](https://www.programiz.com/dsa/dijkstra-algorithm) to see the algorithm in more detail.

The working steps of the program are given below.

1- We go to the path "AlgorthimVisual\bin\Debug". We enter the source graph value, target graph value and distance value in "a.txt" and save it as shown in the picture below.

2- As seen in the picture below, we write our starting graph point in the input section of the form.

3- Click the "Measure Distance" button.

4- The starting graph point is orange. Green ones are available. Reds are out of reach.

5- The lighter the green color, the closer it is.

6- On the new form that opens, we see the graph and distance values.

<div>
<img src="Read Me Images/5.png" >
<img src="Read Me Images/6.png" >
</div>

