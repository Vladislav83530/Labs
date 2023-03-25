using Microsoft.Extensions.DependencyInjection;
using SubscriptionLibrarySystemXML;
using SubscriptionLibrarySystemXML.FileProcessor;
using SubscriptionLibrarySystemXML.FileProcessor.Abstract;

var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileProcessor, FileProcessor>()
                .BuildServiceProvider();

var fileProcessor = serviceProvider.GetRequiredService<IFileProcessor>();

AppManager appManager = new AppManager(fileProcessor);
appManager.Main();