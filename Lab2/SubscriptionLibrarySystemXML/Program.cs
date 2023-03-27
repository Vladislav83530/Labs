using Microsoft.Extensions.DependencyInjection;
using SubscriptionLibrarySystemXML;
using SubscriptionLibrarySystemXML.FileProcessor;
using SubscriptionLibrarySystemXML.FileProcessor.Abstract;
using SubscriptionLibrarySystemXML.Services;
using SubscriptionLibrarySystemXML.Services.Abstract;
using SubscriptionLibrarySystemXML.XMLParser;
using SubscriptionLibrarySystemXML.XMLParser.Abstract;

var serviceProvider = new ServiceCollection()
                .AddSingleton<IFileProcessor, FileProcessor>()
                .AddSingleton<IXmlParser, XmlParser>()
                .AddSingleton<IReaderService, ReaderService>()
                .AddSingleton<IBookService, BookService>()
                .AddSingleton<ISubscriptionService, SubscriptionService>()
                .AddSingleton<IStatisticService, StatisticService>()
                .BuildServiceProvider();

var fileProcessor = serviceProvider.GetRequiredService<IFileProcessor>();
var readerService = serviceProvider.GetRequiredService<IReaderService>();
var bookService = serviceProvider.GetRequiredService<IBookService>();
var subscriptionService = serviceProvider.GetRequiredService<ISubscriptionService>();
var statisticService  = serviceProvider.GetRequiredService<IStatisticService>();
var xmlParser = serviceProvider.GetRequiredService<IXmlParser>();

AppManager appManager = new AppManager(fileProcessor, xmlParser, readerService, bookService, subscriptionService, statisticService);
appManager.Main();