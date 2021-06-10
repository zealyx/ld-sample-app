# LaunchDarkly Sample Application - ACTION BUTTON PLACEMENT EXPERIMENT

In this sample Online Donation web application, we demonstrate the use of feature flags to run a user-experience experiment.

__DO PEOPLE CLICK MORE (DONATE MORE) WHEN THE "DONATE" BUTTON IS PLACED ON THE RIGHT OR THE LEFT?__

![alt text](https://github.com/zealyx/ld-sample-app/Documentation/ld-question.png "Action Button Placement Experiment")

The experiment works as follows.

## How It Works

1. Edit `appsettings.json` and set the value of `LdSdkKey` to your LaunchDarkly SDK key.

2. In your LaunchDarkly project and environment, create a feature flag called `donate-button-on-right`.

![alt text](https://github.com/zealyx/ld-sample-app/Documentation/ld-flag.png "Feature Flag Settings")

3. Run the application in Visual Studio or from the command line:

```
    dotnet run --project ld-sample-app
```

The Online Donation page will load and display the action button `DONATE` either on the right or left based on the evaluated flag.  Since the targeting rule is a percentage rollout (50% on the right and 50% on the left), you can perform the experiment by refreshing the page and clicking the `DONATE` button.

The experiment's data points (evaluated flag value + click action) are logged to the Output console (optionally to a database) to analyze the effectiveness of the action button placement.

![alt text](https://github.com/zealyx/ld-sample-app/Documentation/ld-experiment.png "Feature Flag Settings")
