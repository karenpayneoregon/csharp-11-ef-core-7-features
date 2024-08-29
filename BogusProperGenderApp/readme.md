# About

- An example for having Bogus match first name to the proper gender by passing in the gender to the FirstName constructor while not passing gender to FirstName a female may have a male name and a male may have a female name.
- Log Bogus mocked data to either the console or various formating to a log file using Serilog and Bogus `FinishWith` which allows a developer to view generated data outside an application interface.

---

```csharp
/// <summary>
/// A finalizing action rule applied to <typeparamref name="T"/> after all the rules
/// are executed.
/// </summary>
public virtual Faker<T> FinishWith(Action<Faker, T> action)
{
  var rule = new FinalizeAction<T>
     {
        Action = action,
        RuleSet = currentRuleSet
     };
  this.FinalizeActions[currentRuleSet] = rule;
  return this;
}
```

![Screenshot](assets/screenshot.png)