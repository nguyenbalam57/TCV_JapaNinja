using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TCV_JapaNinja.Models.DatabaseCustoms;
using static TCV_JapaNinja.Class.ConnectedData;

namespace TCV_JapaNinja.Forms.Study.CommonSection
{
    public partial class FormMatching : Form
    {
        /*
         * Ghép cặp
         */
        public FormMatching()
        {
            InitializeComponent();
        }

        #region Data

        private class CustomMatching
        {
            public int Id { get; set; } // Id
            public int GrammarId { get; set; } // Id ngữ pháp
            public int VocabularyId { get; set; } // Id từ vựng
            public int KanjiId { get; set; } // Id kanji
            public int TechnicalId { get; set; } // Id kỹ thuật
            public string LeftText { get; set; } // Text bên trái
            public string RightText { get; set; } // Text bên phải
            public string HintLeft { get; set; } // Gợi ý bên trái
            public string HintRight { get; set; } // Gợi ý bên phải
            public string IsMatching { get; set; } // Đã ghép cặp
            public string IsCheck { get; set; } // Đã kiểm tra
        }

        private List<CustomMatching> MatchingList = new List<CustomMatching>(); // Danh sách ghép cặp 
        

        /// <summary>
        /// 
        /// </summary>
        private enum modeMatching
        {
            None = 0,
            Matching = 1,
            UnMatching = 2
        }


        private void GetDataToListMatChing<T>(List<T> datas, int leaningCatego) where T : class
        {
            enLearningCategory enLearning = (enLearningCategory)leaningCatego;
            MatchingList.Clear(); // Xóa danh sách ghép cặp
            switch (enLearning)
            {
                case enLearningCategory.Kanji:
                    MatchingList = datas as List<CustomMatching>;
                    break;
                case enLearningCategory.Vocabulary:
                    //LoadVocabularyDisplay(datas as List<CustomVocabulary>);
                    break;
                case enLearningCategory.Grammar:
                    //LoadGrammarDisplay(datas as List<CustomGrammar>);
                    break;
                case enLearningCategory.Technical:
                    //LoadTechnicalDisplay(datas as List<CustomTechnical>);
                    break;
            }
        }

        private void GetMatchingsToKanjiList(List<CustomKanji> datas)
        {
            int id = 0; // Id ghép cặp
            foreach (var item in datas)
            {
                MatchingList.Add(new CustomMatching()
                {
                    Id = id++,
                    KanjiId = item.Id,
                    LeftText = item.Kanji,
                    RightText = item.TiengViet,
                    HintLeft = item.Kanji,
                    //HintRight = item.Meaning
                });
            }
        }

        #endregion

        #region Event

        #endregion

        #region UI/UX

        #endregion

        #region Animation

        #endregion

        #region Setting

        #endregion

    }
}
