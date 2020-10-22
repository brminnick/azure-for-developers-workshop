# Azure For Developers Workshop

The Azure cloud is huge (so that’s why they call it the cloud!) and the vast service catalog may appear daunting at first. It doesn’t have to be!

- Learn the browser-based UI of the [Azure Portal](https://azure.microsoft.com/features/azure-portal/?WT.mc_id=mobile-0000-bramin)
- Continue the journey with the built-in, ready-to-run [Azure Cloud Shell](https://azure.microsoft.com/features/cloud-shell/?WT.mc_id=mobile-0000-bramin)
- Explore various ways to deploy web apps written in any language, on any platform, from [virtual machines](https://azure.microsoft.com/services/virtual-machines/?WT.mc_id=mobile-0000-bramin) and [containers](https://azure.microsoft.com/free/kubernetes-service/search/?WT.mc_id=mobile-0000-bramin) to [serverless technologies](https://azure.microsoft.com/services/functions/?WT.mc_id=mobile-0000-bramin)
- Add intelligence to your apps using [Microsoft Cognitive Services](https://azure.microsoft.com/services/cognitive-services/?WT.mc_id=mobile-0000-bramin)
- Protect your apps by applying Azure’s built-in [security features](https://azure.microsoft.com/services/security-center/?WT.mc_id=mobile-0000-bramin)
- Diagnose problems and apply automated machine learning analysis with [Application Insights](https://docs.microsoft.com/azure/application-insights/app-insights-overview/?WT.mc_id=mobile-0000-bramin) 
- Connect your apps with messaging services, load files into [cloud storage](https://azure.microsoft.com/free/storage/?WT.mc_id=mobile-0000-bramin) and discover managed databases for [SQL](https://azure.microsoft.com/free/sql-database/search/?WT.mc_id=mobile-0000-bramin) and [NoSQL](https://azure.microsoft.com/free/cosmos-db/search/?WT.mc_id=mobile-0000-bramin) scenarios
- Tie everything together in a continuous delivery pipeline with [Azure DevOps](https://azure.microsoft.com/services/devops/?WT.mc_id=mobile-0000-bramin) projects

## Agenda

### [1 - Intro to Azure (pptx)](./presentations/01-Intro.pptx)

Let's start by learning the Azure basics!

We'll start by showing the [different resources available in Azure](https://azure.microsoft.com/resources/?WT.mc_id=mobile-0000-bramin), then demonstrate how to access them via the [Azure Portal](https://azure.microsoft.com/features/azure-portal/?WT.mc_id=mobile-0000-bramin) and the [Azure Cloud Shell](https://azure.microsoft.com/features/cloud-shell/?WT.mc_id=mobile-0000-bramin).

### [2 - Azure Storage (pptx)](./presentations/02-storage.pptx)

How do you store stuff in the cloud? In this section we'll explore [Azure Storage](https://azure.microsoft.com/free/storage/?WT.mc_id=mobile-0000-bramin) options including [Azure Blob Storage](https://azure.microsoft.com/services/storage/blobs/?WT.mc_id=mobile-0000-bramin) and [Azure File Storage](https://azure.microsoft.com/services/storage/files/?WT.mc_id=mobile-0000-bramin).

### [3 - Hosting in Azure](labs/03-hosting.md)

In this section, we'll deploy our first website to Azure using [Azure App Service](https://azure.microsoft.com/services/app-service/?WT.mc_id=mobile-0000-bramin). Then we'll connect it with [Azure Application Insights](https://docs.microsoft.com/azure/application-insights/app-insights-overview/?WT.mc_id=mobile-0000-bramin) for advanced logging and rich analytics.

### [4 - Azure Serverless](labs/04-serverless.md)

Serverless today is all the rage! In this section we'll create our first serverless workflow using [Azure Functions](https://azure.microsoft.com/services/functions/?WT.mc_id=mobile-0000-bramin).

### 5 - Azure DevOps

Sit back and relax while we demonstrate how to create a CI/CD pipeline using [Azure DevOps](https://azure.microsoft.com/services/devops/?WT.mc_id=mobile-0000-bramin).

### [6 - Cognitive Services](/labs/06-cognitive_services.md)

Let's add some AI to our app! In this section we will add Sentiment Analysis to the reviews for our Hotels 360 app. For this, we will be leveraging the [Text Analytics API hosted by Cognitive Services](https://azure.microsoft.com/services/cognitive-services/text-analytics/?WT.mc_id=mobile-0000-bramin)

### [7 - Azure Security](/labs/07-azure_security.md)

In this section we will learn how to leverage the security tools available in Azure.

We'll start by learning more about [Azure Security Center](https://azure.microsoft.com/services/security-center/?WT.mc_id=mobile-0000-bramin) and how to leverage its recommendations to add extra layers of security to our app service.

Next, we'll move the secrets out our code and into [Azure Key Vault](https://azure.microsoft.com/services/key-vault/?WT.mc_id=mobile-0000-bramin). Key Vault leverages HSMs ([hardware security modules](https://en.wikipedia.org/wiki/Hardware_security_module)) to help us avoid storing secrets in our source code.
