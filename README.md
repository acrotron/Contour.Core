# Contour.Core

A .NET library for generating contour lines and polygons from scattered geospatial data using triangulation-based interpolation. Designed for creating noise contour maps around airports.

## Features

- Generate contour lines and polygons from triangulated point data with scalar values
- Lambert Conformal Conic map projection (compatible with AEDT/Esri)
- Triangle edge intersection detection and linear interpolation
- Built on [NetTopologySuite](https://github.com/NetTopologySuite/NetTopologySuite) for geometry operations

## Getting Started

### Prerequisites

- .NET 8.0 or later

### Installation

Add a reference to the `Contour.Core` project or package.

### Usage

The library exposes the `IContourGenerator` interface with two main operations:

```csharp
// Set up triangulated input data
generator.SetTriangles(triangles);

// Generate contour lines for specified intervals
var lines = generator.GenerateContourLines(intervals);

// Generate contour polygons
var polygons = generator.GenerateContourPolygons(intervals);
```

## Project Structure

- **Contour.Core** - Core library
- **Contour.Core.Test** - Unit tests (MSTest)

## License

[MIT](LICENSE) - Copyright 2026 Acrotron
