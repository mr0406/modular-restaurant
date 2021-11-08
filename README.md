# Modular Restaurant

![](https://github.com/mr0406/modular-restaurant/.github/workflows/dotnet/badge.svg)

## Introduction
Modular Restaurant is an open source project written in .NET 5.0.\
The idea behind this repository is to write a real application related to the restaurant domain.  

We are going to use concepts like: 
  - Modular monolith
  - CQRS
  - DDD
  - Event storming

The main purpose of that project is to try new software design ideas and became better software developers.

## Architecture
Modular monolith was chosen to be project architecture, the whole project idea is based on that concept.
The idea is to have independents modules and some shared concepts stored in one solution.

Each module can have different inside architecture. 
Modules with complex domain logic will be using DDD and Clean Architecture.
Modules that are CRUDs will be written as simple as they can be. (no complex architecture, no DDD)

## Authors
Oliwia Szwon - https://github.com/Maderaffie \
Marcin Rakowski - https://github.com/mr0406

## License
MIT License - https://github.com/mr0406/modular-restaurant/blob/main/LICENSE

## Inspirations
https://github.com/kgrzybek/modular-monolith-with-ddd \
https://github.com/devmentors/Confab
https://www.eventstorming.com/
