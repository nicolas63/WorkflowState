
## What is WorkflowState ?

Simple workflow management 


## Package & Status

Package  | Build status | NuGet 
-------- | ------------ | ------------ 
WorkflowState.Core | ![Build status](https://ci.appveyor.com/api/projects/status/4y2vpph0h5rsglts?svg=true) | [![NuGet](http://img.shields.io/nuget/v/WorkflowState.Core.svg)](https://www.nuget.org/packages/WorkflowState.Core/)


## How do I get started?

### Install the package

```
Install-Package WorkflowState.Core
```

### Configure your workflow 

```csharp
workflow.Configure(conf =>
{
    conf.CreateTransition(startState, endState, trigger);
});
```

### Use it 

```csharp
var stateInformation = workflow.GetNextState(startState, trigger);
```

### Exporting your workflow 

```csharp
var graph = GraphHelper.ExportWorkflow(workflow);
```

### Visualize your workflow on site who draw dot graph like https://dreampuf.github.io/GraphvizOnline/

![Alt text](./docs/Workflow.png)

## Contributing

A good way to get started (flow)

1. Fork the WorkflowState repos.
1. Create a new branch in you current repos from the 'master' branch.
1. 'Check out' the code with Git
1. Check [contributing.md](CONTRIBUTING.md)
1. push commits and create a Pull Request (PR) to WorkflowState

## License

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details