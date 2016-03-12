using PropertyChanged;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using ullu.Models;

namespace ullu.ViewModels
{
    [ImplementPropertyChanged]
    public class AddStoreViewModel : BaseViewModel
    {
        public void ReloadTags()
        {
            var tags = new ObservableCollection<TagItem>(){
                new TagItem() { Name = "#TagExample" },
                new TagItem() { Name = "#Xamarin" },
                new TagItem() { Name = "#DanielLuberda" },
                new TagItem() { Name = "#Test" },
                new TagItem() { Name = "#XamarinForms" },
                new TagItem() { Name = "#TagEntryView" },
                new TagItem() { Name = "#TapMe!" },
                new TagItem() { Name = "#itsworking!" },
            };

            Items = tags;
        }
        public AddStoreViewModel()
        {
            Items = new ObservableCollection<TagItem>();
        }
        public void RemoveTag(TagItem tagItem)
        {
            Items.Remove(tagItem);
        }

        public TagItem ValidateAndReturn(string tag)
        {
            if (string.IsNullOrWhiteSpace(tag))
                return null;

            var tagString = tag.StartsWith("#") ? tag : "#" + tag;

            if (Items != null && Items.Any(v => v.Name.Equals(tagString, StringComparison.OrdinalIgnoreCase)))
                return null;

            return new TagItem()
            {
                Name = tagString
            };
        }

        public ObservableCollection<TagItem> Items { get; set; }
    }
}
