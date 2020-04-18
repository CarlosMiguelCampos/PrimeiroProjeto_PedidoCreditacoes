﻿using CMA.ISMAI.Core;
using CMA.ISMAI.Logging.Interface;
using CMA.ISMAI.Sagas.Service.Interface;
using CMA.ISMAI.Sagas.Service.Model;
using System;
using System.Collections.Generic;

namespace CMA.ISMAI.Sagas.Service
{
    public class SagaService : ISagaService
    {
        private readonly ILog _log;
        private readonly IHttpRequest _httpRequest;
        public SagaService(ILog log, IHttpRequest httpRequest)
        {
            this._log = log;
            this._httpRequest = httpRequest;
        }

        public List<string> GetCardAttachments(string cardId)
        {
            _log.Info($"GetCardAttachments for card Id {cardId}... getting attachments");
            List<string> cardAttachments = _httpRequest.GetCardAttachments(cardId).Result;
            _log.Info($"GetCardAttachments for card Id {cardId} - the result was {cardAttachments.Count} files");
            return cardAttachments;
        }

        public bool GetCardState(string cardId)
        {
            _log.Info($"CoordenatorExcelAction for card Id {cardId}");
            bool getCardState = _httpRequest.CardStateAsync(cardId).Result;
            _log.Info($"CoordenatorExcelAction for card Id {cardId} - the result was {getCardState.ToString()}");
            return getCardState;
        }

        public bool IsSummerBreakTime()
        {
            try
            {
                return Convert.ToBoolean(BaseConfiguration.ReturnSettingsValue("SummerDealy", "Activate-delay"));
            }
            catch (Exception ex)
            {
                _log.Fatal(ex.ToString());
            }
            return false;
        }

        public string PostNewCard(CardDto card)
        {
            _log.Info($"PostNewCard for card Name {card.Name}");
            string createCard = _httpRequest.CardPostAsync(card).Result;
            return string.IsNullOrEmpty(createCard) ? string.Empty : createCard;
        }
    }
}
