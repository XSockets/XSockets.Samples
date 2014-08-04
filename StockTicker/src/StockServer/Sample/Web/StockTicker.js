/// <reference path="js/knockout-2.2.1.js" />

//KnockoutJS ViewModel
var StockItem = function (symbol, dayOpen, dayHigh, dayLow, price, lastChange, percentChange) {
    var self = this;
    this.Symbol = symbol;
    this.DayOpen = dayOpen;
    this.DayLow = ko.observable(dayLow);
    this.DayHigh = ko.observable(dayHigh);
    this.Price = ko.observable(price);
    this.Change = ko.observable(lastChange);
    this.Percent = ko.observable(percentChange);
    this.Active = ko.observable(true);   
    this.Trend = ko.computed(function () {
        if (!self.Active()) return "inactive";
        if (self.Change() === 0) return "zero";
        return self.Change() < 0 ? "down" : "up";
    }, this);
    this.DayTrend = ko.computed(function () {
        if (!self.Active()) return "inactive";
        if (self.Price() === self.DayOpen) return "zero";
        return self.Price() < self.DayOpen ? "down" : "up";
    }, this);
    this.ToggleState = ko.computed(function () {
        if (self.Active()) return "green";        
        return "gray";
    }, this);
    this.ToggleText = ko.computed(function () {
        if (self.Active()) return "On";
        return "Off";
    }, this);
};

var StockViewModel = function () {

    this.Stocks = ko.observableArray([]);

    this.StockSubscriptions = ko.observableArray([]);
    
    this.AddOrUpdate = function (stock) {
        var match = ko.utils.arrayFirst(this.Stocks(), function (item) {
            return stock.Symbol === item.Symbol;
        });
        if (!match) {
            this.Stocks.push(new StockItem(stock.Symbol, stock.DayOpen, stock.DayHigh, stock.DayLow, stock.Price, stock.LastChange, stock.PercentChange));
            this.StockSubscriptions.push(stock.Symbol);
            //Sort the array since it might be bad after adding
            this.Stocks.sort(function (left, right) { return left.Symbol == right.Symbol ? 0 : (left.Symbol < right.Symbol ? -1 : 1); });
        } else {
            match.Price(stock.Price);
            match.DayLow(stock.DayLow);
            match.DayHigh(stock.DayHigh);
            match.Change(stock.LastChange);
            match.Percent(stock.PercentChange);
        }
    };       
};