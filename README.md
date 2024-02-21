# TemplateForU - template for Unity projects
This template provides an out-of-the-box solution for project structuring, code architecture, service implementation, and the use of Zenject's DI container.

* [Introduction](#introduction)
* [Dependencies](#dependencies)
* [Differences](#differences)
* [Projects on TemplateForU](#projects-on-templateforu)

## Introduction
This template was inspired by [KSyndicateZenjectTemplate](https://github.com/DizzyJump/KSyndicateZenjectTemplate) and [Unity empty project template (UEPT)](https://github.com/vangogih/unity-empty-project-template) and is an amalgamation of those templates and my solutions to various situations in the project.

The project structure was taken from the [Unity empty project template (UEPT)](https://github.com/vangogih/unity-empty-project-template).
The rest of the project was based on personal experience and [KSyndicateZenjectTemplate](https://github.com/DizzyJump/KSyndicateZenjectTemplate).

## Dependencies
1. Addressables
2. [Zenject (Extenject)](https://github.com/modesttree/Zenject)
3. [UniTask](https://github.com/Cysharp/UniTask)

## Differences
### Project structure
### The rest of the project
* Removed the asynchrony in the methods of the `StateMachine` script.
* Zenject is only used as a Di container. Removed `PlaceholderFactory`.
* Minor changes in `PoolingService`. Created abstract class `PoolObject` which inherits from `MonoBehaviour`.
* Added `AudioService`.

## Projects on TemplateForU
* [Pong](https://github.com/JokiADF/PongShowcase)
